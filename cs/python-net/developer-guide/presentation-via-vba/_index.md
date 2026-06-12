---
title: Spravovat VBA projekty v prezentacích pomocí Pythonu
linktitle: Prezentace přes VBA
type: docs
weight: 250
url: /cs/python-net/presentation-via-vba/
keywords:
- makro
- VBA
- VBA makro
- přidat makro
- odebrat makro
- extrahovat makro
- přidat VBA
- odebrat VBA
- extrahovat VBA
- PowerPoint
- OpenDocument
- prezentace
- Python
- Aspose.Slides
description: "Objevte, jak pomocí VBA generovat a upravovat prezentace PowerPoint a OpenDocument s Aspose.Slides pro Python přes .NET a zefektivnit tak svůj pracovní postup."
---
## **Přehled**

Tento článek zkoumá klíčové funkce Aspose.Slides pro Python prostřednictvím .NET pro práci s makry v prezentacích PowerPoint. Knihovna poskytuje pohodlné nástroje pro přidávání, odstraňování a extrahování makrů, což vám umožňuje automatizovat vytváření a úpravu prezentací.

S Aspose.Slides můžete:

- Zrychlit vývoj prezentací – automatizace rutinních úkolů snižuje čas potřebný k přípravě materiálů.
- Cílit na flexibilitu – schopnost spravovat makra vám umožňuje přizpůsobit prezentace konkrétním úkolům a scénářům.
- Integrace dat – jednoduchá integrace s externími zdroji dat pomáhá udržovat obsah snímků aktuální.
- Zjednodušení údržby – centralizovaná správa makrů usnadňuje provádění změn a aktualizaci prezentací.

Článek dále představuje praktické příklady, jak používat Aspose.Slides k efektivní práci s makry v PowerPointu.

Namespace [aspose.slides.vba](https://reference.aspose.com/slides/cs/python-net/aspose.slides.vba/) poskytuje třídy pro práci s makry a kódem VBA.

{{% alert title="Note" color="warning" %}}
Když převádíte prezentaci obsahující makra do jiného formátu (PDF, HTML atd.), Aspose.Slides makra ignoruje – nepřenesou se do výstupního souboru.

Když přidáte makra do prezentace nebo znovu uložíte prezentaci, která makra obsahuje, Aspose.Slides zapíše bajty makra beze změny.

Aspose.Slides **nikdy** neprovádí makra v prezentaci.
{{% /alert %}}

## **Přidání VBA makrů**

Aspose.Slides poskytuje třídu [VbaProject](https://reference.aspose.com/slides/cs/python-net/aspose.slides.vba/vbaproject/), která umožňuje vytvořit VBA projekty (a odkazy na projekty) a upravovat existující moduly.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/).
1. Použijte konstruktor [VbaProject](https://reference.aspose.com/slides/cs/python-net/aspose.slides.vba/vbaproject/#constructors) pro přidání nového VBA projektu.
1. Přidejte modul do VBA projektu.
1. Nastavte zdrojový kód modulu.
1. Přidejte odkaz na `<stdole>`.
1. Přidejte odkaz na **Microsoft Office**.
1. Propojte odkazy s VBA projektem.
1. Uložte prezentaci.

Následující kód v Pythonu ukazuje, jak přidat VBA makro od začátku do prezentace:

```python
import aspose.slides as slides

# Vytvořte instanci třídy Presentation.
with slides.Presentation() as presentation:

    # Vytvořte nový VBA projekt.
    presentation.vba_project = slides.vba.VbaProject()

    # Přidejte prázdný modul do VBA projektu.
    module = presentation.vba_project.modules.add_empty_module("Module")

    # Nastavte zdrojový kód modulu.
    module.source_code = """
        Sub Test(oShape As Shape)
            MsgBox "Hello, world!"
        End Sub
    """

    # Vytvořte odkaz na <stdole>.
    stdole_reference = slides.vba.VbaReferenceOleTypeLib("stdole",
        "*\\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\\Windows\\system32\\stdole2.tlb#OLE Automation")

    # Vytvořte odkaz na Microsoft Office.
    office_reference = slides.vba.VbaReferenceOleTypeLib("Office",
        "*\\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\\Program Files\\Common Files\\Microsoft Shared\\OFFICE14\\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Přidejte odkazy do VBA projektu.
    presentation.vba_project.references.add(stdole_reference)
    presentation.vba_project.references.add(office_reference)

    # Uložte prezentaci.
    presentation.save("macros.pptm", slides.export.SaveFormat.PPTM)
```

{{% alert color="primary" %}}
Možná budete chtít vyzkoušet **Aspose** [Macro Remover](https://products.aspose.app/slides/cs/remove-macros), bezplatnou webovou aplikaci pro odstraňování maker z dokumentů PowerPoint, Excel a Word.
{{% /alert %}}

## **Odstranění VBA makrů**

Pomocí vlastnosti [vba_project](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/vba_project/) třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) můžete odstranit VBA makro.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a načtěte prezentaci, která makro obsahuje.
1. Přistupte k modulu makra a odstraňte jej.
1. Uložte upravenou prezentaci.

Následující kód v Pythonu ukazuje, jak odstranit VBA makro:

```python
import aspose.slides as slides

# Načtěte prezentaci, která obsahuje makro.
with slides.Presentation("VBA.pptm") as presentation:
    
    # Přistupte k VBA modulu.
    vba_module = presentation.vba_project.modules[0]

    # Odstraňte VBA modul.
    presentation.vba_project.modules.remove(vba_module)

    # Uložte prezentaci.
    presentation.save("removed_macro.pptm", slides.export.SaveFormat.PPTM)
```

## **Extrahování VBA makrů**

Pomocí vlastnosti `modules` ve třídě [VbaProject](https://reference.aspose.com/slides/cs/python-net/aspose.slides.vba/vbaproject/) můžete získat přístup ke všem modulům VBA projektu. Třída [VbaModule](https://reference.aspose.com/slides/cs/python-net/aspose.slides.vba/vbamodule/) může být použita k extrakci vlastností modulu, jako je název a kód.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a načtěte prezentaci, která makro obsahuje.
1. Zkontrolujte, zda prezentace obsahuje VBA projekt.
1. Projděte všechny moduly ve VBA projektu a zobrazte makra.

Následující kód v Pythonu ukazuje, jak extrahovat VBA makra z prezentace:

```python
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Zkontrolujte, zda prezentace obsahuje VBA projekt.
    if presentation.vba_project is not None:
        for module in presentation.vba_project.modules:
            print(module.name)
            print(module.source_code)
```

## **Zjištění, zda je VBA projekt chráněn heslem**

Pomocí vlastnosti [VbaProject.is_password_protected](https://reference.aspose.com/slides/cs/python-net/aspose.slides.vba/vbaproject/is_password_protected/) můžete zjistit, zda jsou vlastnosti projektu chráněny heslem.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) a načtěte prezentaci, která obsahuje makro.
1. Zkontrolujte, zda prezentace obsahuje [VBA projekt](https://reference.aspose.com/slides/cs/python-net/aspose.slides.vba/vbaproject/).
1. Zkontrolujte, zda je VBA projekt chráněn heslem, abyste mohli zobrazit jeho vlastnosti.

```py
import aspose.slides as slides

with slides.Presentation("VBA.pptm") as presentation:
    # Zkontrolujte, zda prezentace obsahuje VBA projekt.
    if presentation.vba_project is not None:
        if presentation.vba_project.is_password_protected:
            print(f"The VBA Project '{presentation.vba_project.name}' is protected by password to view project properties.")
```

## **Často kladené otázky**

**Co se stane s makry, pokud uložím prezentaci jako PPTX?**

Makra budou odstraněna, protože formát PPTX nepodporuje VBA. Pro zachování maker zvolte PPTM, PPSM nebo POTM.

**Může Aspose.Slides spouštět makra uvnitř prezentace, například pro obnovení dat?**

Ne. Knihovna nikdy nespouští VBA kód; spuštění je možné pouze v PowerPointu s odpovídajícím nastavením zabezpečení.

**Je podpora práce s ovládacími prvky ActiveX propojenými s VBA kódem?**

Ano, můžete přistupovat k existujícím [ActiveX controls](/slides/cs/python-net/activex/), upravovat jejich vlastnosti a odstraňovat je. To je užitečné, když makra interagují s ActiveX.