---
title: Prezentace chráněné proti zápisu v Pythonu
linktitle: Ochrana proti zápisu
type: docs
weight: 25
url: /cs/python-java/write-protected-presentation/
keywords:
- ochrana proti zápisu
- ochrana proti zápisu PowerPoint
- heslo pro úpravu
- omezit úpravy prezentace
- odstranit ochranu proti zápisu
- ověřit heslo pro úpravy
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Nastavte, detekujte, ověřujte a odstraňujte hesla pro ochranu proti zápisu v prezentacích PowerPoint PPT a PPTX pomocí Aspose.Slides pro Python přes Java."
---
## **Úvod**

Heslo pro ochranu proti zápisu omezuje úpravy prezentace, ale nešifruje její obsah. Uživatelé mohou načíst a zobrazit prezentaci chráněnou proti zápisu i bez hesla. V závislosti na aplikaci mohou také být schopni upravit obsah a uložit jej pod jiným názvem, takže ochrana proti zápisu by neměla být považována za mechanismus důvěrnosti.

Otevírací heslo slouží k jinému účelu: šifruje prezentaci a je vyžadováno pro načtení jejího obsahu. Pro šifrování prezentace nebo ověření otevíracího hesla viz [Password-Protect Presentations](/slides/cs/python-java/password-protected-presentation/).

Postupy v tomto článku platí pro prezentace ve formátech PPT i PPTX. Příklady používají soubory PPTX; při ukládání do PPT použijte příponu `.ppt` a odpovídající formát ukládání PPT.

## **Nastavení ochrany proti zápisu u prezentace**

Použijte [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/protectionmanager/#setWriteProtection) k přiřazení hesla pro úpravu prezentace. Uložení prezentace zachová nastavení ochrany.

Následující příklad nastavuje ochranu proti zápisu u prezentace PPTX:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().setWriteProtection("modify_password")
    presentation.save("write-protected-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Načtení prezentace chráněné proti zápisu**

Protože ochrana proti zápisu nešifruje obsah prezentace, není vyžadováno žádné heslo pro načtení prezentace. Heslo je relevantní pouze při ověřování oprávnění k úpravě chráněné prezentace.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation

presentation = Presentation("write-protected-pres.pptx")
try:
    print("Slide count: " + str(presentation.getSlides().size()))
finally:
    presentation.dispose()
```

Nepřevádějte heslo pro ochranu proti zápisu do [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#setPassword). Tato metoda přijímá otevírací heslo pro šifrovaný obsah. Pokud má prezentace oba typy ochrany, předložte otevírací heslo pro její načtení a heslo pro ochranu proti zápisu zpracujte samostatně.

## **Odstranění ochrany proti zápisu z prezentace**

Použijte [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/protectionmanager/#removeWriteProtection) k odstranění omezení úprav a poté prezentaci uložte.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("write-protected-pres.pptx")
try:
    presentation.getProtectionManager().removeWriteProtection()
    presentation.save("write-protection-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Kontrola, zda je prezentace chráněna proti zápisu**

Pro inspekci souboru bez vytvoření úplné instance [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) zavolejte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationfactory/#getPresentationInfo) a zkontrolujte [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#isWriteProtected). Metoda používá [NullableBool](https://reference.aspose.com/slides/cs/python-java/aspose.slides/nullablebool/) a vrací `NullableBool.True_`, pokud je detekována ochrana proti zápisu.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() == NullableBool.True_:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

Přetížení pro proud v [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationfactory/#getPresentationInfo) poskytuje stejnou informaci pro prezentaci dodanou jako proud.

## **Ověření hesla pro ochranu proti zápisu**

Použijte [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#checkWriteProtection) k ověření hesla pro úpravy bez načtení celé prezentace. Nejprve zkontrolujte [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#isWriteProtected), aby aplikace požadovala nebo ověřovala heslo pouze v případě, že je ochrana proti zápisu přítomna.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import NullableBool, PresentationFactory

presentation_info = PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx")

if presentation_info.isWriteProtected() != NullableBool.True_:
    print("The presentation is not write protected.")
elif presentation_info.checkWriteProtection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#checkWriteProtection) ověřuje pouze heslo pro ochranu proti zápisu. Neověřuje otevírací heslo ani nestanovuje, zda lze načíst šifrovaný obsah. Naopak [PresentationInfo.checkPassword](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#checkPassword) ověřuje pouze otevírací heslo. Pokud již byla kompletní prezentace načtena, [ProtectionManager.checkWriteProtection](https://reference.aspose.com/slides/cs/python-java/aspose.slides/protectionmanager/#checkWriteProtection) poskytuje ekvivalentní kontrolu ochrany proti zápisu prostřednictvím svého správce ochrany.

V produkčních aplikacích neukládejte hesla do protokolů ani je nezahrnujte do diagnostických zpráv. Vyhněte se zbytečným opakovaným pokusům o ověření a uchovávejte hesla v paměti pouze po nezbytně nutnou dobu.

{{% alert color="info" title="Viz také" %}}
- [Prezentace chráněné heslem](/slides/cs/python-java/password-protected-presentation/)
- [Prezentace jen pro čtení](/slides/cs/python-java/read-only-presentation/)
- [Digitální podpis v PowerPointu](/slides/cs/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Šifruje ochrana proti zápisu prezentaci?**

Ne. Omezuje úpravy, ale ponechává obsah prezentace dostupný pro načtení a prohlížení.

**Je heslo pro ochranu proti zápisu vyžadováno k otevření prezentace?**

Ne. Pouze otevírací heslo je vyžadováno pro načtení šifrovaného obsahu prezentace.

**Může mít prezentace současně otevírací heslo i heslo pro ochranu proti zápisu?**

Ano. Otevírací heslo předáte prostřednictvím možností načtení k otevření šifrované prezentace a heslo pro ochranu proti zápisu ověříte samostatně, když je vyžadováno oprávnění k úpravám.