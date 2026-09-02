---
title: Zabezpečení prezentací heslem v Pythonu
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
- kontrola hesla prezentace
- otevřít šifrovanou prezentaci
- odstranit šifrování
- PowerPoint
- PPT
- PPTX
- prezentace
- Python
- Aspose.Slides
description: "Šifrování, detekce, ověřování, otevírání a dešifrování PowerPoint PPT a PPTX prezentací chráněných heslem v Pythonu s Aspose.Slides."
---
## **Přehled**

Otevírací heslo šifruje prezentaci. Správné heslo je vyžadováno k načtení a zobrazení obsahu prezentace, takže tato ochrana poskytuje důvěrnost.

Otevírací heslo se liší od hesla pro ochranu proti zápisu. Ochrana proti zápisu omezuje úpravy, ale nešifruje obsah ani nezabraňuje načtení prezentace. Pro správu hesel pro úpravu prezentací viz [Write-Protect Presentations](/slides/cs/python-net/write-protected-presentation/).

Níže uvedené pracovní postupy platí pro prezentace PPT i PPTX. Příklady používají oba formáty, kde je důležité jejich chování při práci se soubory i se streamy.

## **Šifrování prezentace otevíracím heslem**

Pro přiřazení otevíracího hesla použijte [ProtectionManager.encrypt](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/encrypt/). Poté použijte [Presentation.save](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/save/), abyste uložili šifrovanou prezentaci.

Následující příklad šifruje prezentaci PPTX:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.encrypt("open_password")
    presentation.save("encrypted-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Načtení šifrované prezentace**

Nastavte [LoadOptions.password](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/password/) na otevírací heslo a při načítání souboru předáte možnosti do [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/). Načítání selže, pokud je vyžadováno otevírací heslo, ale zadané heslo chybí nebo je nesprávné.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    # Pracovat s dešifrovanou prezentací.
    pass
```

## **Odstranění šifrování z prezentace**

Načtěte prezentaci pomocí jejího otevíracího hesla, zavolejte [ProtectionManager.remove_encryption](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/remove_encryption/), a výsledek uložte. Uložená prezentace pak může být načtena bez hesla.

```python
import aspose.slides as slides

load_options = slides.LoadOptions()
load_options.password = "open_password"

with slides.Presentation("encrypted-pres.pptx", load_options) as presentation:
    presentation.protection_manager.remove_encryption()
    presentation.save("encryption-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Ověření otevíracího hesla před načtením**

Pro získání [PresentationInfo](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/) aniž byste vytvářeli kompletní instanci prezentace, použijte [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationfactory/get_presentation_info/). Před požádáním o heslo nebo jeho ověřením zkontrolujte [PresentationInfo.is_password_protected](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/is_password_protected/). Pokud je ochrana přítomna, ověřte zadanou hodnotu pomocí [PresentationInfo.check_password](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/check_password/).

### **Pracovní postup s cestou k souboru**

Následující příklad ověřuje otevírací heslo pro soubor PPTX, předává ověřenou hodnotu do [LoadOptions.password](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/password/), a poté načte kompletní prezentaci:

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

### **Pracovní postup se streamem**

Přetížení streamu metody [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationfactory/get_presentation_info/) poskytuje stejný postup. Před načtením kompletní prezentace z tohoto streamu resetujte pozici vyhledávaného streamu.

Následující příklad používá soubor PPT:

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

### **Návratové hodnoty metody CheckPassword**

[PresentationInfo.check_password](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/check_password/) vrací `True` pouze když prezentace má otevírací heslo a zadané heslo je správné. V následujících situacích vrací `False`:
- Heslo je nesprávné.
- Prezentace nemá otevírací heslo.
- Zadané heslo je `None` nebo prázdné.

Chování je stejné pro prezentace PPT i PPTX.

## **Kontrola, zda je načtená prezentace šifrovaná**

Po načtení prezentace se správným heslem zkontrolujte [ProtectionManager.is_encrypted](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/is_encrypted/), abyste potvrdili, že zdrojová prezentace byla šifrována. Pro detekci ochrany otevíracím heslem před načtením použijte `PresentationInfo.is_password_protected`, jak je uvedeno výše.

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
Nezaznamenávejte otevírací hesla do protokolů ani je nezahrnujte do diagnostických zpráv. Vyhněte se zbytečným opakovaným pokusům o ověření, uchovávejte hesla v paměti pouze po nezbytně potřebnou dobu a při okamžitém načtení prezentace použijte výsledek úspěšné validace znovu.
{{% /alert %}}

## **Ochrana prezentace heslem online**

1. Otevřete aplikaci [Aspose.Slides Lock](https://products.aspose.app/slides/cs/lock).
1. Vyberte nebo nahrajte prezentaci.
1. Zadejte heslo pro ochranu při prohlížení.
1. Volitelně zadejte samostatné heslo pro ochranu úprav.
1. Použijte ochranu a stáhněte výsledný soubor.

{{% alert color="info" title="Viz také" %}}
- [Write-Protect Presentations](/slides/cs/python-net/write-protected-presentation/)
- [Digital Signature in PowerPoint](/slides/cs/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Jaký je rozdíl mezi otevíracím heslem a heslem pro ochranu proti zápisu?**

Otevírací heslo šifruje prezentaci a je vyžadováno k načtení jejího obsahu. Heslo pro ochranu proti zápisu omezuje úpravy bez šifrování obsahu.

**Mohu ověřit otevírací heslo, aniž bych načítal všechny snímky?**

Ano. Získejte informace o prezentaci, zjistěte, zda je přítomna ochrana otevíracím heslem, a ověřte heslo před vytvořením kompletní instance prezentace.

**Podporují workflowy pro kontrolu hesla jak PPT, tak PPTX?**

Ano. Detekce a ověření hesla na základě cesty k souboru i streamu se chová stejně pro prezentace PPT i PPTX.