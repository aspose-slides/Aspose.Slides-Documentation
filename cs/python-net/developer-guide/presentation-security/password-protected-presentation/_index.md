---
title: Prezentace chráněné heslem v Pythonu
linktitle: Ochrana heslem
type: docs
weight: 20
url: /cs/python-net/password-protected-presentation/
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
description: "Šifrujte, detekujte, ověřujte, otevírejte a dešifrujte prezentace PowerPoint PPT a PPTX chráněné heslem v Pythonu s Aspose.Slides."
---
## **Přehled**

Otevírací heslo šifruje prezentaci. Správné heslo je vyžadováno pro načtení a zobrazení obsahu prezentace, takže tato ochrana poskytuje důvěrnost.

Otevírací heslo se liší od hesla pro ochranu proti zápisu. Ochrana proti zápisu omezuje úpravy, ale nešifruje obsah ani nebrání načtení prezentace. Pro správu hesel pro úpravu prezentací viz [Write-Protect Presentations](/slides/cs/python-net/write-protected-presentation/).

Níže uvedené postupy platí pro prezentace PPT i PPTX. Příklady používají oba formáty, kde je důležité chování na souborech i streamových operacích.

## **Šifrování prezentace otevíracím heslem**

Použijte [ProtectionManager.encrypt](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/encrypt/) k přiřazení otevíracího hesla. Pak použijte [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/) k uložení šifrované prezentace.

Následující příklad šifruje PPTX prezentaci:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Zveřejnění vlastností dokumentu**

Ve výchozím nastavení zahrnuje Aspose.Slides vlastnosti dokumentu do šifrování prezentace. Vlastnost [ProtectionManager.encrypt_document_properties](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/encrypt_document_properties/) řídí toto chování nezávisle na šifrování obsahu snímků. Nastavte ji na `False` před voláním [ProtectionManager.encrypt](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/encrypt/) v případě, že systém indexování, klasifikace, vyhledávání nebo správy dokumentů potřebuje číst metadata bez otevíracího hesla.

Následující příklad vytvoří šifrovanou PPTX prezentaci a zároveň ponechá vestavěné vlastnosti dokumentu veřejné:

```python
import aspose.slides as slides

with slides.Presentation() as presentation:
    properties = presentation.document_properties
    properties.author = "Contoso Knowledge Management"
    properties.title = "Quarterly Product Roadmap"
    properties.keywords = "roadmap, planning, internal"

    presentation.slides[0].name = "Encrypted presentation content"
    presentation.protection_manager.encrypt_document_properties = False
    presentation.protection_manager.encrypt("open_password")
    presentation.save("public-properties-encrypted.pptx", slides.export.SaveFormat.PPTX)
```

Nastavení `encrypt_document_properties` na `False` nezpřístupní snímky, mistrovské snímky, rozvržení, tvary, média ani jiný obsah prezentace. Ovlivní pouze vlastnosti dokumentu. Pro čtení těchto vlastností bez načítání šifrovaného obsahu viz [Manage Presentation Properties](/slides/cs/python-net/presentation-properties/).

## **Načtení šifrované prezentace**

Nastavte [LoadOptions.password](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/password/) na otevírací heslo a předávejte možnosti při volání [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/) při načítání souboru. Načtení selže, pokud je požadováno otevírací heslo, ale zadané heslo chybí nebo je nesprávné.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Pracujte s dešifrovanou prezentací.
    pass
```

## **Odstranění šifrování z prezentace**

Načtěte prezentaci s jejím otevíracím heslem, zavolejte [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/remove_encryption/) a výsledek uložte. Uložená prezentace pak může být načtena bez hesla.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ověření otevíracího hesla před načtením**

Použijte [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationfactory/get_presentation_info/) k získání [PresentationInfo](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/) bez vytváření úplné instance prezentace. Zkontrolujte [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/is_password_protected/) před požádáním o heslo nebo jeho ověřením. Pokud je ochrana přítomna, ověřte zadanou hodnotu pomocí [PresentationInfo.check_password](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/check_password/).

### **Postup s cestou k souboru**

Následující příklad ověří otevírací heslo pro PPTX soubor, předá ověřenou hodnotu do [LoadOptions.password](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/password/) a poté načte úplnou prezentaci:

```python
import aspose.slides as slides

file_path = "protected-presentation.pptx"
password = "open_password"
presentation_info = slides.PresentationFactory.instance.get_presentation_info(file_path)

if not presentation_info.is_password_protected:
    print("The presentation does not have an opening password.")
elif not presentation_info.check_password(password):
    print("The opening password is incorrect.")
else:
    load_options = slides.LoadOptions()
    load_options.password = password

    with slides.Presentation(file_path, load_options) as presentation:
        print("The presentation was validated and loaded successfully.")
```

### **Postup se streamem**

Přetížení streamu metody [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationfactory/get_presentation_info/) poskytuje stejný postup. Před načtením úplné prezentace ze streamu nastavte pozici vyhledávaného streamu na začátek.

Následující příklad používá PPT soubor:

```python
import aspose.slides as slides

password = "open_password"

with open("protected-presentation.ppt", "rb") as presentation_stream:
    presentation_info = slides.PresentationFactory.instance.get_presentation_info(presentation_stream)

    if not presentation_info.is_password_protected:
        print("The presentation does not have an opening password.")
    elif not presentation_info.check_password(password):
        print("The opening password is incorrect.")
    else:
        presentation_stream.seek(0)
        load_options = slides.LoadOptions()
        load_options.password = password

        with slides.Presentation(presentation_stream, load_options) as presentation:
            print("The presentation was validated and loaded successfully.")
```

### **Návratové hodnoty CheckPassword**

[PresentationInfo.check_password](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/check_password/) vrací `True` pouze tehdy, když má prezentace otevírací heslo a zadané heslo je správné. Vrací `False` v následujících případech:

- Heslo je nesprávné.
- Prezentace nemá otevírací heslo.
- Zadané heslo je `None` nebo prázdné.

Chování je stejné pro PPT i PPTX prezentace.

## **Kontrola, zda je načtená prezentace šifrována**

Po načtení prezentace se správným heslem zkontrolujte [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/is_encrypted/) k potvrzení, že původní prezentace byla šifrována. Pro detekci ochrany otevíracím heslem před načtením použijte `PresentationInfo.is_password_protected` podle výše uvedeného postupu.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    is_encrypted = presentation.protection_manager.is_encrypted
    print("The presentation is encrypted: " + str(is_encrypted))
```

## **Doporučení pro zabezpečení**

{{% alert color="warning" title="Zabezpečení" %}}
Nezaznamenávejte otevírací hesla ani je neuvádějte v diagnostických zprávách. Vyhněte se zbytečným opakovaným pokusům o ověření, uchovávejte hesla v paměti jen po dobu nezbytně potřebnou a znovu použijte úspěšný výsledek ověření při okamžitém načtení prezentace.

Veřejné vlastnosti dokumentu mohou odhalit jména autorů, názvy, předměty, klíčová slova, informace o firmě, komentáře a vlastní hodnoty, i když je obsah prezentace šifrován. Šifrujte citlivá metadata společně s prezentací. Zveřejnění vlastností by mělo být explicitním rozhodnutím učiněným jen tehdy, když systémy musí indexovat, klasifikovat, vyhledávat nebo spravovat soubor bez otevíracího hesla.
{{% /alert %}}

## **Šifrování prezentace online**

1. Otevřete aplikaci [Aspose.Slides Lock](https://products.aspose.app/slides/cs/lock).
1. Vyberte nebo nahrajte prezentaci.
1. Zadejte heslo pro ochranu zobrazení.
1. Volitelně zadejte samostatné heslo pro ochranu úprav.
1. Použijte ochranu a stáhněte výsledný soubor.

{{% alert color="info" title="Viz také" %}}
- [Write-Protect Presentations](/slides/cs/python-net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/cs/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi otevíracím heslem a heslem pro ochranu proti zápisu?**

Otevírací heslo šifruje prezentaci a je vyžadováno pro načtení jejího obsahu. Heslo pro ochranu proti zápisu omezuje úpravy bez šifrování obsahu.

**Mohu ověřit otevírací heslo bez načtení všech snímků?**

Ano. Získejte informace o prezentaci, zkontrolujte, zda je přítomna ochrana otevíracím heslem, a ověřte heslo před vytvořením úplné instance prezentace.

**Může aplikace číst metadata bez otevíracího hesla?**

Ano, ale jen pokud byla prezentace šifrována s nastavením `encrypt_document_properties` na `False`. Aplikace pak musí použít režim načítání jen vlastností dokumentu popsaný v [Manage Presentation Properties](/slides/cs/python-net/presentation-properties/).

**Podporují pracovní postupy kontroly hesla jak PPT, tak PPTX?**

Ano. Detekce a ověření hesla na základě cesty k souboru i streamu se chovají stejným způsobem pro PPT i PPTX prezentace.