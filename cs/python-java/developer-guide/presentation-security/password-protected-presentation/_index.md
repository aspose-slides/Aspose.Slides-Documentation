---
title: Prezentace chráněné heslem v Pythonu
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/python-java/password-protected-presentation/
keywords:
- prezentace chráněná heslem
- otevírací heslo
- šifrovat PowerPoint
- dešifrovat PowerPoint
- ověřit heslo prezentace
- zkontrolovat heslo prezentace
- otevřít šifrovanou prezentaci
- odstranit šifrování
- PowerPoint
- PPT
- PPTX
- prezentace
- Python
- Aspose.Slides
description: "Šifrujte, detekujte, ověřujte, otevírejte a dešifrujte prezentace PowerPoint PPT a PPTX chráněné heslem pomocí Aspose.Slides pro Python přes Java."
---
## **Přehled**

Otevírací heslo šifruje prezentaci. Správné heslo je vyžadováno k načtení a zobrazení obsahu prezentace, takže tato ochrana poskytuje důvěrnost.

Otevírací heslo se liší od hesla pro zápisovou ochranu. Zápisová ochrana omezuje úpravy, ale nešifruje obsah ani nebrání načtení prezentace. Pro správu hesel pro úpravu prezentací viz [Write-Protect Presentations](/slides/cs/python-java/write-protected-presentation/).

Níže uvedené pracovní postupy platí jak pro prezentace PPT, tak PPTX. Příklady používají oba formáty tam, kde je důležité chování založené na souborech i na streamu.

## **Šifrování prezentace pomocí otevíracího hesla**

K přiřazení otevíracího hesla použijte [ProtectionManager.encrypt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/protectionmanager/#encrypt). Poté použijte [Presentation.save](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/#save) k uložení šifrované prezentace.

Následující příklad šifruje PPTX prezentaci:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation("pres.pptx")
try:
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("encrypted-pres.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Zachovat dokumentové vlastnosti veřejné**

Ve výchozím nastavení zahrnuje Aspose.Slides dokumentové vlastnosti do šifrování prezentace. Metoda [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) řídí toto chování nezávisle na šifrování obsahu snímků. Před voláním [ProtectionManager.encrypt](https://reference.aspose.com/slides/cs/python-java/aspose.slides/protectionmanager/#encrypt) předávejte `False`, pokud musí systém pro indexaci, klasifikaci, vyhledávání nebo správu dokumentů číst metadata bez otevíracího hesla.

Následující příklad vytvoří šifrovanou PPTX prezentaci a přitom ponechá její vestavěné dokumentové vlastnosti veřejné:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import Presentation, SaveFormat

presentation = Presentation()
try:
    properties = presentation.getDocumentProperties()
    properties.setAuthor("Contoso Knowledge Management")
    properties.setTitle("Quarterly Product Roadmap")
    properties.setKeywords("roadmap, planning, internal")

    presentation.getSlides().get_Item(0).setName("Encrypted presentation content")
    presentation.getProtectionManager().setEncryptDocumentProperties(False)
    presentation.getProtectionManager().encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

Předání `False` metodě [ProtectionManager.setEncryptDocumentProperties](https://reference.aspose.com/slides/cs/python-java/aspose.slides/protectionmanager/#setEncryptDocumentProperties) neznamená, že snímky, mastery, rozložení, tvary, média nebo jiný obsah prezentace budou veřejné. Ovlivňuje jen dokumentové vlastnosti. Pro čtení těchto vlastností bez načítání šifrovaného obsahu viz [Manage Presentation Properties](/slides/cs/python-java/presentation-properties/).

## **Načtení šifrované prezentace**

Nastavte [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#setPassword) na otevírací heslo a předávejte možnosti do [Presentation](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentation/) při načítání souboru. Načítání selže, pokud je vyžadováno otevírací heslo, ale poskytnuté heslo chybí nebo je nesprávné.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    # Pracovat s dešifrovanou prezentací.
    pass
finally:
    presentation.dispose()
```

## **Odstranění šifrování z prezentace**

Načtěte prezentaci s jejím otevíracím heslem, zavolejte [ProtectionManager.removeEncryption](https://reference.aspose.com/slides/cs/python-java/aspose.slides/protectionmanager/#removeEncryption) a uložte výsledek. Uložená prezentace pak může být načtena bez hesla.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, SaveFormat

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    presentation.getProtectionManager().removeEncryption()
    presentation.save("encryption-removed.pptx", SaveFormat.Pptx)
finally:
    presentation.dispose()
```

## **Ověření otevíracího hesla před načtením**

Pomocí [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationfactory/#getPresentationInfo) získáte [PresentationInfo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/) bez vytvoření kompletní instance prezentace. Před požádáním o heslo nebo jeho ověřením zkontrolujte [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#isPasswordProtected). Pokud je ochrana přítomna, ověřte zadanou hodnotu pomocí [PresentationInfo.checkPassword](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#checkPassword).

### **Pracovní postup se souborovou cestou**

Následující příklad ověří otevírací heslo pro soubor PPTX, předá ověřenou hodnotu do [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/python-java/aspose.slides/loadoptions/#setPassword) a poté načte kompletní prezentaci:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = PresentationFactory.getInstance().getPresentationInfo(file_path)

if not presentation_info.isPasswordProtected():
    print("The presentation does not have an opening password.")
elif not presentation_info.checkPassword(password):
    print("The opening password is incorrect.")
else:
    load_options = LoadOptions()
    load_options.setPassword(password)

    presentation = Presentation(file_path, load_options)
    try:
        print("The presentation was validated and loaded successfully.")
    finally:
        presentation.dispose()
```

### **Pracovní postup se streamem**

Přetížení pro stream u [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationfactory/#getPresentationInfo) poskytuje stejný postup. Před načtením kompletní prezentace z tohoto streamu resetujte pozici vyhledatelného streamu.

Následující příklad používá soubor PPT:

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation, PresentationFactory

FileInputStream = jpype.JClass("java.io.FileInputStream")

password = "open_password"

presentation_stream = FileInputStream("protected-presentation.ppt")
try:
    presentation_info = PresentationFactory.getInstance().getPresentationInfo(presentation_stream)

    if not presentation_info.isPasswordProtected():
        print("The presentation does not have an opening password.")
    elif not presentation_info.checkPassword(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.getChannel().position(0)

        load_options = LoadOptions()
        load_options.setPassword(password)

        presentation = Presentation(presentation_stream, load_options)
        try:
            print("The presentation was validated and loaded successfully.")
        finally:
            presentation.dispose()
finally:
    presentation_stream.close()
```

### **Návratové hodnoty metody checkPassword**

[PresentationInfo.checkPassword](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#checkPassword) vrací `True` pouze když má prezentace otevírací heslo a zadané heslo je správné. V následujících případech vrací `False`:
- Heslo je nesprávné.
- Prezentace nemá otevírací heslo.
- Zadané heslo je `None` nebo prázdné.

Chování je stejné pro prezentace PPT i PPTX.

## **Zkontrolujte, zda je načtená prezentace šifrovaná**

Po načtení prezentace se správným heslem zkontrolujte [ProtectionManager.isEncrypted](https://reference.aspose.com/slides/cs/python-java/aspose.slides/protectionmanager/#isEncrypted), abyste potvrdili, že původní prezentace byla šifrována. Pro detekci ochrany otevíracím heslem před načtením použijte [PresentationInfo.isPasswordProtected](https://reference.aspose.com/slides/cs/python-java/aspose.slides/presentationinfo/#isPasswordProtected) jak je uvedeno výše.

```python
import jpype
import asposeslides

if not jpype.isJVMStarted():
    jpype.startJVM()

from asposeslides.api import LoadOptions, Presentation

load_options = LoadOptions()
load_options.setPassword("open_password")

presentation = Presentation("encrypted-pres.pptx", load_options)
try:
    is_encrypted = presentation.getProtectionManager().isEncrypted()
    print(f"The presentation is encrypted: {is_encrypted}")
finally:
    presentation.dispose()
```

## **Doporučení pro zabezpečení**

{{% alert color="warning" title="Zabezpečení" %}}
Nevyplňujte (logujte) otevírací hesla ani je nezahrnujte do diagnostických zpráv. Vyhněte se zbytečným opakovaným pokusům o ověření, uchovávejte hesla v paměti pouze po dobu, kterou potřebujete, a při okamžitém načítání prezentace znovu použijte úspěšný výsledek ověření.

Veřejné dokumentové vlastnosti mohou odhalit jména autorů, názvy, předměty, klíčová slova, informace o společnosti, komentáře a vlastní hodnoty, i když je obsah prezentace šifrován. Šifrujte citlivá metadata spolu s prezentací. Zanechání vlastností veřejných by mělo být explicitním rozhodnutím učiněným jen tehdy, když systémy musí indexovat, klasifikovat, vyhledávat nebo spravovat soubor bez otevíracího hesla.
{{% /alert %}}

## **Ochrana prezentace heslem online**

1. Otevřete aplikaci [Aspose.Slides Lock](https://products.aspose.app/slides/cs/lock).
2. Vyberte nebo nahrajte prezentaci.
3. Zadejte heslo pro ochranu zobrazení.
4. Volitelně zadejte samostatné heslo pro ochranu úprav.
5. Použijte ochranu a stáhněte vzniklý soubor.

{{% alert color="info" title="Viz také" %}}
- [Zápisová ochrana prezentací](/slides/cs/python-java/write-protected-presentation/)
- [Digitální podpis v PowerPointu](/slides/cs/python-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi otevíracím heslem a heslem pro zápisovou ochranu?**

Otevírací heslo šifruje prezentaci a je nutné k načtení jejího obsahu. Heslo pro zápisovou ochranu omezuje úpravy bez šifrování obsahu.

**Mohu ověřit otevírací heslo bez načtení všech snímků?**

Ano. Získejte informace o prezentaci, zkontrolujte, zda je přítomna ochrana otevíracím heslem, a ověřte heslo před vytvořením kompletní instance prezentace.

**Může aplikace číst metadata bez otevíracího hesla?**

Ano, ale pouze pokud byla prezentace šifrována s vypnutým šifrováním dokumentových vlastností. Aplikace pak musí použít režim načítání jen dokumentových vlastností popsaný v [Manage Presentation Properties](/slides/cs/python-java/presentation-properties/).

**Podporují postupy ověřování hesla jak PPT, tak PPTX?**

Ano. Detekce a ověřování hesla na základě cesty k souboru i streamu se chová stejně u prezentací PPT i PPTX.