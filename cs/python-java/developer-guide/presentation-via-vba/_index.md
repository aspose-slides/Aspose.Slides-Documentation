---
title: Správa projektů VBA v prezentacích pomocí Pythonu
linktitle: Prezentace pomocí VBA
type: docs
weight: 250
url: /cs/python-java/presentation-via-vba/
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
- Python
- Java
- Aspose.Slides
description: "Objevte, jak pomocí VBA generovat a upravovat prezentace PowerPoint a OpenDocument pomocí Aspose.Slides pro Python via Java a zefektivnit svůj pracovní postup."
---
## **Úvod**

Aspose.Slides poskytuje třídy a rozhraní pro práci s makry a kódem VBA.

{{% alert title="Varování" color="warning" %}} 

When you convert a presentation containing macros to a different file format (PDF, HTML, etc.), Aspose.Slides ignores all macros (macros are not carried into the resulting file).

When you add macros to a presentation or resave a presentation containing macros, Aspose.Slides simply writes the bytes for the macros.

Aspose.Slides **never** runs the macros in a presentation.

{{% /alert %}}

## **Přidání VBA makrů**

Aspose.Slides poskytuje třídu [VbaProject](https://reference.aspose.com/slides/cs/python-java/aspose.slides/vbaproject/), která vám umožní vytvářet projekty VBA (a odkazy na projekty) a upravovat existující moduly. Třídu [VbaProject](https://reference.aspose.com/slides/cs/python-java/aspose.slides/vbaproject/) můžete použít ke správě VBA vloženého do prezentace.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/).
1. Použijte konstruktor [VbaProject](https://reference.aspose.com/slides/cs/python-java/aspose.slides/vbaproject/#vbaproject) k přidání nového projektu VBA.
1. Přidejte modul do projektu VBA.
1. Nastavte zdrojový kód modulu.
1. Přidejte odkazy na `stdole`.
1. Přidejte odkazy na **Microsoft Office**.
1. Přiřaďte odkazy k projektu VBA.
1. Uložte prezentaci.

Tento Python kód ukazuje, jak přidat VBA makro od začátku do prezentace:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat, VbaProject, VbaReferenceOleTypeLib

presentation = Presentation()
try:
    # Vytvořte nový projekt VBA.
    vba_project = VbaProject()
    presentation.setVbaProject(vba_project)

    # Přidejte prázdný modul a nastavte jeho zdrojový kód.
    module = vba_project.getModules().addEmptyModule("Module")
    module.setSourceCode('Sub Test(oShape As Shape)\n    MsgBox "Test"\nEnd Sub')

    # Vytvořte odkazy na stdole a Microsoft Office.
    stdole_reference = VbaReferenceOleTypeLib("stdole", r"*\G{00020430-0000-0000-C000-000000000046}#2.0#0#C:\Windows\system32\stdole2.tlb#OLE Automation")
    office_reference = VbaReferenceOleTypeLib("Office", r"*\G{2DF8D04C-5BFA-101B-BDE5-00AA0044DE52}#2.0#0#C:\Program Files\Common Files\Microsoft Shared\OFFICE14\MSO.DLL#Microsoft Office 14.0 Object Library")

    # Přidejte odkazy do VBA projektu.
    vba_project.getReferences().add(stdole_reference)
    vba_project.getReferences().add(office_reference)

    # Uložte prezentaci.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

{{% alert color="info" title="Poznámka" %}} 

Můžete se podívat na **Aspose** [Macro Remover](https://products.aspose.app/slides/cs/remove-macros), což je zdarma webová aplikace používaná k odstraňování maker z dokumentů PowerPoint, Excel a Word. 

{{% /alert %}} 

## **Odstranění VBA makrů**

Pomocí metody [getVbaProject](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#getvbaproject) třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) můžete odstranit VBA makro.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a načtěte prezentaci obsahující makro.
1. Získejte přístup k modulu makra a odstraňte jej.
1. Uložte upravenou prezentaci.

Tento Python kód ukazuje, jak odstranit VBA makro:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

# Načtěte prezentaci obsahující makro.
presentation = Presentation("VBA.pptm")
try:
    # Získejte přístup k VBA modulu a odstraňte jej.
    vba_project = presentation.getVbaProject()
    if vba_project is not None and len(list(vba_project.getModules())) > 0:
        module = vba_project.getModules().get_Item(0)
        vba_project.getModules().remove(module)

    # Uložte prezentaci.
    presentation.save("test.pptm", SaveFormat.Pptm)
finally:
    presentation.dispose()
```

## **Extrahování VBA makrů**

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a načtěte prezentaci obsahující makro.
2. Zkontrolujte, zda prezentace obsahuje VBA projekt.
3. Procházejte všechny moduly obsažené v projektu VBA a zobrazte makra.

Tento Python kód ukazuje, jak extrahovat VBA makra z prezentace obsahující makra:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

# Načtěte prezentaci obsahující makro.
presentation = Presentation("VBA.pptm")
try:
    # Zkontrolujte, zda prezentace obsahuje projekt VBA.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        for module in vba_project.getModules():
            print(module.getName())
            print(module.getSourceCode())
finally:
    presentation.dispose()
```

## **Zkontrolujte, zda je VBA projekt chráněn heslem**

Pomocí metody [VbaProject.isPasswordProtected](https://reference.aspose.com/slides/cs/python-java/aspose.slides/vbaproject/#ispasswordprotected) můžete zjistit, zda jsou vlastnosti projektu chráněny heslem.

1. Vytvořte instanci třídy [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) a načtěte prezentaci, která obsahuje makro.
2. Zkontrolujte, zda prezentace obsahuje [VBA projekt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/vbaproject/).
3. Zkontrolujte, zda je projekt VBA chráněn heslem, a prohlédněte si jeho vlastnosti.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("VBA.pptm")
try:
    # Zkontrolujte, zda prezentace obsahuje projekt VBA.
    vba_project = presentation.getVbaProject()
    if vba_project is not None:
        if vba_project.isPasswordProtected():
            print(f"The VBA project '{vba_project.getName()}' is password-protected for viewing its properties.")
finally:
    presentation.dispose()
```

## **Často kladené otázky**

**Co se stane s makry, když uložíte prezentaci jako PPTX?**

Makra budou odstraněna, protože formát PPTX nepodporuje VBA. Pokud chcete makra zachovat, zvolte PPTM, PPSM nebo POTM.

**Může Aspose.Slides spouštět makra v prezentaci, například pro obnovení dat?**

Ne. Knihovna nikdy neprovádí kód VBA; spuštění je možné pouze v PowerPointu s odpovídajícím nastavením zabezpečení.

**Je podporována práce s ovládacími prvky ActiveX spojenými s kódem VBA?**

Ano, můžete přistupovat k existujícím [ActiveX controls](/slides/cs/python-java/activex/), upravovat jejich vlastnosti a odstraňovat je. To je užitečné, když makra interagují s ActiveX.