---
title: "Správa VBA projektů v prezentacích v .NET"
linktitle: "Prezentace přes VBA"
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
description: "Objevte, jak pomocí VBA s Aspose.Slides pro .NET generovat a manipulovat s prezentacemi PowerPoint a OpenDocument a zefektivnit tak svůj pracovní postup."
---
## **Úvod**

Jmenný prostor [Aspose.Slides.Vba](https://reference.aspose.com/slides/cs/net/aspose.slides.vba/) obsahuje třídy a rozhraní pro práci s makry a kódem VBA.

{{% alert title="Note" color="warning" %}} 

Když převádíte prezentaci obsahující makra do jiného formátu souboru (PDF, HTML atd.), Aspose.Slides ignoruje všechna makra (makra nejsou přenesena do výsledného souboru).

Když přidáte makra do prezentace nebo znovu uložíte prezentaci obsahující makra, Aspose.Slides jednoduše zapíše bajty makr.

Aspose.Slides **nikdy** nespouští makra v prezentaci.

{{% /alert %}}

## **Přidat VBA makra**

Aspose.Slides poskytuje třídu [VbaProject](https://reference.aspose.com/slides/cs/net/aspose.slides.vba/vbaproject/), která umožňuje vytvářet VBA projekty (a odkazy na projekty) a upravovat existující moduly. Rozhraní [IVbaProject](https://reference.aspose.com/slides/cs/net/aspose.slides.vba/ivbaproject/) lze použít ke správě VBA vloženého v prezentaci.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/).
2. Použijte konstruktor [VbaProject](https://reference.aspose.com/slides/cs/net/aspose.slides.vba/vbaproject/vbaproject/#constructor) k přidání nového VBA projektu.
3. Přidejte modul do VbaProject.
4. Nastavte zdrojový kód modulu.
5. Přidejte odkazy na <stdole>.
6. Přidejte odkazy na **Microsoft Office**.
7. Propojte odkazy s VBA projektem.
8. Uložte prezentaci.

Tento C# kód ukazuje, jak od začátku přidat VBA makro do prezentace:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;
using Aspose.Slides.Vba;

// Vytvoří instanci třídy prezentace
using (Presentation presentation = new Presentation())
{
    // Vytvoří nový VBA projekt
    presentation.VbaProject = new VbaProject();

    // Přidá prázdný modul do VBA projektu
    IVbaModule module = presentation.VbaProject.Modules.AddEmptyModule("Module");

    // Nastaví zdrojový kód modulu
    module.SourceCode = @"Sub Test(oShape As Shape) MsgBox ""Test"" End Sub";

    // Vytvoří odkaz na <stdole>
    VbaReferenceOleTypeLib stdoleReference =
        new VbaReferenceOleTypeLib("stdole", "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation");

    // Vytvoří odkaz na Office
    VbaReferenceOleTypeLib officeReference =
        new VbaReferenceOleTypeLib("Office", "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library");

    // Přidá odkazy do VBA projektu
    presentation.VbaProject.References.Add(stdoleReference);
    presentation.VbaProject.References.Add(officeReference);

    // Uloží prezentaci
    presentation.Save("AddVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

{{% alert color="info" %}} 

Možná budete chtít vyzkoušet **Aspose** [Macro Remover](https://products.aspose.app/slides/cs/remove-macros), což je bezplatná webová aplikace sloužící k odstranění maker z dokumentů PowerPoint, Excel a Word. 

{{% /alert %}} 

## **Odstranit VBA makra**
Pomocí vlastnosti [VbaProject](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/vbaproject/) ve třídě [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) můžete odebrat VBA makro.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a načtěte prezentaci obsahující makro.
2. Získejte přístup k modulu Macro a odstraňte jej.
3. Uložte upravenou prezentaci.

Tento C# kód ukazuje, jak odstranit VBA makro:

```c#
using Aspose.Slides;
using Aspose.Slides.Export;

// Načte prezentaci obsahující makro
using (Presentation presentation = new Presentation("VBA.pptm"))
{
    // Přistoupí k Vba modulu a odstraní jej
    presentation.VbaProject.Modules.Remove(presentation.VbaProject.Modules[0]);

    // Uloží prezentaci
    presentation.Save("RemovedVBAMacros_out.pptm", SaveFormat.Pptm);
}
```

## **Extrahovat VBA makra**
1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a načtěte prezentaci obsahující makro.
2. Zkontrolujte, zda prezentace obsahuje VBA projekt.
3. Projděte všechny moduly obsažené ve VBA projektu a zobrazte makra.

Tento C# kód ukazuje, jak extrahovat VBA makra z prezentace obsahující makra:

```c#
using Aspose.Slides;
using Aspose.Slides.Vba;

    // Načte prezentaci obsahující makro
using (Presentation pres = new Presentation("VBA.pptm"))
{
	if (pres.VbaProject != null) // Zkontroluje, zda prezentace obsahuje VBA projekt
	{
		foreach (IVbaModule module in pres.VbaProject.Modules)
		{
			Console.WriteLine(module.Name);
			Console.WriteLine(module.SourceCode);
		}
	}
}
```

## **Zkontrolovat, zda je VBA projekt chráněn heslem**

Pomocí vlastnosti [IVbaProject.IsPasswordProtected](https://reference.aspose.com/slides/cs/net/aspose.slides.vba/ivbaproject/ispasswordprotected/) můžete zjistit, zda jsou vlastnosti projektu chráněny heslem.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/net/aspose.slides/presentation/) a načtěte prezentaci, která obsahuje makro.
2. Zkontrolujte, zda prezentace obsahuje [VBA projekt](https://reference.aspose.com/slides/cs/net/aspose.slides.vba/vbaproject/).
3. Zkontrolujte, zda je VBA projekt chráněn heslem, abyste mohli zobrazit jeho vlastnosti.

```cs
using Aspose.Slides;

using (Presentation presentation = new Presentation("VBA.pptm"))
{
    if (presentation.VbaProject != null) // Zkontrolujte, zda prezentace obsahuje VBA projekt.
    {
        if (presentation.VbaProject.IsPasswordProtected)
        {
            Console.WriteLine($"The VBA Project '{presentation.VbaProject.Name}' is protected by password to view project properties.");
        }
    }
}
```

## **Často kladené otázky**

### Co se stane s makry, když uložíte prezentaci jako PPTX?

Makra budou odstraněna, protože formát PPTX nepodporuje VBA. Chcete-li makra zachovat, zvolte PPTM, PPSM nebo POTM.

### Může Aspose.Slides spouštět makra v prezentaci, například pro obnovení dat?

Ne. Knihovna nikdy neprovádí kód VBA; provedení je možné pouze v PowerPointu s odpovídajícím nastavením zabezpečení.

### Je podpora práce s ActiveX ovládacími prvky propojenými s kódem VBA?

Ano, můžete přistupovat k existujícím [ActiveX controls](/slides/cs/net/activex/), měnit jejich vlastnosti a odstraňovat je. To je užitečné, když makra interagují s ActiveX.