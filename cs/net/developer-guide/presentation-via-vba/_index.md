---
title: Správa projektů VBA v prezentacích v .NET
linktitle: Prezentace pomocí VBA
type: docs
weight: 250
url: /cs/net/presentation-via-vba/
keywords:
- makro
- VBA
- VBA makro
- přidat makro
- odstranit makro
- extrahovat makro
- přidat VBA
- odstranit VBA
- extrahovat VBA
- PowerPoint
- OpenDocument
- prezentace
- .NET
- C#
- Aspose.Slides
description: "Objevte, jak pomocí VBA v Aspose.Slides pro .NET generovat a manipulovat s prezentacemi PowerPoint a OpenDocument a zefektivnit tak Váš pracovní proces."
---
## **Úvod**

The [Aspose.Slides.Vba](https://reference.aspose.com/slides/cs/net/aspose.slides.vba/) namespace contains classes and interfaces for working with macros and VBA code.

{{% alert title="Note" color="warning" %}} 

When you convert a presentation containing macros to a different file format (PDF, HTML, etc.), Aspose.Slides ignores all macros (macros are not carried into the resulting file).

When you add macros to a presentation or resave a presentation containing macros, Aspose.Slides simply writes the bytes for the macros.

Aspose.Slides **never** runs the macros in a presentation.

{{% /alert %}}

## **Přidání VBA maker**

Aspose.Slides provides the [VbaProject](https://reference.aspose.com/slides/cs/net/aspose.slides.vba/vbaproject/) class to allow you to create VBA projects (and project references) and edit existing modules. You can use the [IVbaProject](https://reference.aspose.com/slides/cs/net/aspose.slides.vba/ivbaproject/) interface to manage VBA embedded in a presentation.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) class.
1. Use the [VbaProject](https://reference.aspose.com/slides/cs/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) constructor to add a new VBA project.
1. Add a module to the VbaProject.
1. Set the module source code.
1. Add references to <stdole>.
1. Add references to **Microsoft Office**.
1. Associate the references with the VBA project.
1. Save the presentation.

This C# code shows you how to add a VBA macro from scratch to a presentation:

```c#
    // Vytvoří instanci třídy Presentation
using (Presentation presentation = new Presentation())
{
    // Vytvoří nový projekt VBA
    presentation.VbaProject = new VbaProject();

    // Přidá prázdný modul do projektu VBA
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");
  
    // Nastaví zdrojový kód modulu
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // Vytvoří odkaz na <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Vytvoří odkaz na Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Přidá odkazy do projektu VBA
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

            
    // Uloží prezentaci
    presentation.Save(dataDir + "AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="primary" %}} 

You may want to check out **Aspose** [Macro Remover](https://products.aspose.app/slides/cs/remove-macros), which a free web app used to remove macros from PowerPoint, Excel, and Word documents. 

{{% /alert %}} 

## **Odstranění VBA maker**
Using the [VbaProject](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/vbaproject/) property under the [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) class, you can remove a VBA macro.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) class and load the presentation containing the macro.
1. Access the Macro module and remove it.
1. Save the modified presentation.

This C# code shows you how to remove a VBA macro:

```c#
    // Načte prezentaci obsahující makro
using (Presentation presentation = new Presentation(dataDir + "VBA.pptm"))
{
    // Přistoupí k modulu VBA a odstraní jej 
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Uloží prezentaci
    presentation.Save(dataDir + "RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **Extrahování VBA maker**
1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) class and load the presentation containing the macro.
2. Check if the presentation contains a VBA Project.
3. Loop through all the modules contained in the VBA Project to view the macros.

This C# code shows you how to extract VBA macros from a presentation containing macros:

```c#
    // Načte prezentaci obsahující makro
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Zkontroluje, zda prezentace obsahuje projekt VBA
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **Zjištění, zda je VBA projekt chráněn heslem**

Using the [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/cs/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) property, you can determine whether a project’s properties are password-protected.

1. Create an instance of the [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) class and load a presentation that contains a macro.
2. Check whether the presentation contains a [VBA project](https://reference.aspose.com/slides/cs/net/aspose.slides.vba/vbaproject/).
3. Check whether the VBA project is password-protected to view its properties.

```cs
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Zkontrolujte, zda prezentace obsahuje projekt VBA.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **FAQ**

**Co se stane s makry, pokud uložíme prezentaci jako PPTX?**

Makra budou odstraněna, protože PPTX nepodporuje VBA. Pro zachování maker vyberte PPTM, PPSM nebo POTM.

**Může Aspose.Slides spouštět makra v prezentaci, například pro načtení dat?**

Ne. Knihovna nikdy nespouští VBA kód; provádění je možné pouze v PowerPointu s odpovídajícím nastavením zabezpečení.

**Je podporována práce s ActiveX ovládacími prvky napojenými na VBA kód?**

Ano, můžete přistupovat k existujícím [ActiveX controls](/slides/cs/net/activex/), měnit jejich vlastnosti a odstraňovat je. To je užitečné, když makra interagují s ActiveX.