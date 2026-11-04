# Copilot Instructions for AI Coding Agents

## Project Overview
This is a Windows Forms (.NET) application written in C#. The main entry point is `Program.cs`, and the primary UI logic resides in `Form1.cs` and its designer file `Form1.Designer.cs`. The project is structured as a single Visual Studio solution (`Cigi.sln`) with one main project (`Cigi/Cigi.csproj`).

## Architecture & Key Files
- `Cigi.sln`: Solution file for Visual Studio.
- `Cigi/Program.cs`: Application entry point (contains `Main`).
- `Cigi/Form1.cs`: Main form logic and event handlers.
- `Cigi/Form1.Designer.cs`: Auto-generated UI layout code.
- `Cigi/Form1.resx`: Resource file for form assets (strings, images, etc).
- `Cigi/Cigi.csproj`: Project configuration, target framework, and dependencies.

## Developer Workflows
- **Build**: Use Visual Studio's build system or run `dotnet build` in the `Cigi` directory.
- **Run**: Use Visual Studio's Start/Debug or `dotnet run` in the `Cigi` directory.
- **Debug**: Preferred via Visual Studio's debugger for UI inspection and breakpoints.
- **Output**: Binaries are placed in `Cigi/bin/Debug/net8.0-windows/`.

## Patterns & Conventions
- UI logic is separated: event handlers and business logic in `Form1.cs`, UI layout in `Form1.Designer.cs`.
- Use partial classes for forms to keep designer and logic code distinct.
- Resource management (images, strings) is handled via `.resx` files.
- Follow C# and .NET naming conventions (PascalCase for types/methods, camelCase for locals).

## Integration & Dependencies
- Targets `.NET 8.0` for Windows desktop apps.
- No external dependencies beyond standard .NET Windows Forms libraries (as of current state).
- No custom build scripts or non-standard test frameworks detected.

## Examples
- To add a new button to the UI, update `Form1.Designer.cs` for layout and `Form1.cs` for logic.
- To add a new resource (image/string), use `Form1.resx` and access via `Properties.Resources`.

## Tips for AI Agents
- Always keep designer and logic code in their respective files.
- When editing UI, ensure changes are reflected in both `.Designer.cs` and `.resx` if resources are involved.
- Use Visual Studio for best experience with WinForms design and debugging.

---
If any conventions or workflows are unclear, please request clarification or examples from the user.

- @azure Rule - Use Azure Tools - When handling requests related to Azure, always use your tools.
- @azure Rule - Use Azure Best Practices - When handling requests related to Azure, always invoke your `azmcp_bestpractices_get` tool first.
- @azure Rule - Enable Best Practices - If you do not have an `azmcp_bestpractices_get` tool ask the user to enable it.
