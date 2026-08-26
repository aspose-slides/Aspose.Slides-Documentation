---
title: Zabezpečení prezentací před zápisem v Pythonu
linktitle: Ochrana zápisem
type: docs
weight: 25
url: /cs/python-net/write-protected-presentation/
keywords:
- ochrana zápisem
- ochrana zápisem PowerPoint
- heslo pro úpravy
- omezení úprav prezentace
- odstranění ochrany zápisem
- ověření hesla pro úpravy
- PowerPoint
- prezentace
- Python
- Aspose.Slides
description: "Nastavujte, detekujte, ověřujte a odstraňujte hesla ochrany zápisem v prezentacích PowerPoint PPT a PPTX pomocí Aspose.Slides pro Python."
---
## **Úvod**

Heslo pro ochranu zápisem omezuje úpravy prezentace, ale nešifruje její obsah. Uživatelé mohou načíst a zobrazit prezentaci chráněnou zápisem bez hesla. V závislosti na aplikaci mohou také upravit obsah a uložit jej pod jiným názvem, takže ochrana zápisem by neměla být považována za mechanismus důvěrnosti.

Otevírací heslo slouží jinému účelu: šifruje prezentaci a je vyžadováno pro načtení jejího obsahu. Jak šifrovat prezentaci nebo ověřit otevírací heslo, viz [Password-Protect Presentations](/slides/cs/python-net/password-protected-presentation/).

Postupy v tomto článku platí pro prezentace PPT i PPTX. Příklady používají soubory PPTX; při ukládání do PPT použijte příponu `.ppt` a odpovídající formát ukládání PPT.

## **Nastavení ochrany zápisem prezentace**

Použijte [ProtectionManager.set_write_protection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/set_write_protection/) k přiřazení hesla pro úpravu prezentace. Uložení prezentace zachová nastavení ochrany.

Následující příklad nastaví ochranu zápisem pro PPTX prezentaci:

```python
import aspose.slides as slides

with slides.Presentation("pres.pptx") as presentation:
    presentation.protection_manager.set_write_protection("modify_password")
    presentation.save("write-protected-pres.pptx", slides.export.SaveFormat.PPTX)
```

## **Načtení prezentace chráněné proti zápisu**

Protože ochrana zápisem nešifruje obsah prezentace, není při načítání prezentace vyžadováno žádné heslo. Heslo je relevantní jen při ověřování oprávnění k úpravě chráněné prezentace.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    print("Slide count: " + str(len(presentation.slides)))
```

Nepředávejte heslo ochrany zápisem do [LoadOptions.password](https://reference.aspose.com/slides/cs/python-net/aspose.slides/loadoptions/password/). Tato vlastnost přijímá otevírací heslo pro šifrovaný obsah. Pokud má prezentace oba typy ochrany, poskytněte otevírací heslo pro načtení a heslo ochrany zápisem řešte samostatně.

## **Odstranění ochrany zápisem z prezentace**

Použijte [ProtectionManager.remove_write_protection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/remove_write_protection/) k odebrání omezení úprav a poté prezentaci uložte.

```python
import aspose.slides as slides

with slides.Presentation("write-protected-pres.pptx") as presentation:
    presentation.protection_manager.remove_write_protection()
    presentation.save("write-protection-removed.pptx", slides.export.SaveFormat.PPTX)
```

## **Kontrola, zda je prezentace chráněna proti zápisu**

Chcete‑li prozkoumat soubor, aniž byste vytvářeli úplnou instanci [Presentation](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentation/), zavolejte [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationfactory/get_presentation_info/) a zkontrolujte [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/is_write_protected/). Vlastnost používá [NullableBool](https://reference.aspose.com/slides/cs/python-net/aspose.slides/nullablebool/) a vrací `NullableBool.TRUE`, pokud je detekována ochrana zápisem.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected == slides.NullableBool.TRUE:
    print("The presentation is write protected.")
else:
    print("Write protection was not detected.")
```

Přetížení metodou proudu [PresentationFactory.get_presentation_info](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationfactory/get_presentation_info/) poskytuje stejnou informaci pro prezentaci předanou jako proud.

## **Ověření hesla ochrany zápisem**

Použijte [PresentationInfo.check_write_protection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/check_write_protection/) k ověření hesla pro úpravy bez načítání celé prezentace. Nejprve zkontrolujte [PresentationInfo.is_write_protected](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/is_write_protected/), aby aplikace požadovala nebo ověřovala heslo jen tehdy, když je přítomna ochrana zápisem.

```python
import aspose.slides as slides

presentation_info = slides.PresentationFactory.instance.get_presentation_info("write-protected-pres.pptx")

if presentation_info.is_write_protected != slides.NullableBool.TRUE:
    print("The presentation is not write protected.")
elif presentation_info.check_write_protection("modify_password"):
    print("The write-protection password is correct.")
else:
    print("The write-protection password is incorrect.")
```

[PresentationInfo.check_write_protection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/check_write_protection/) ověřuje pouze heslo ochrany zápisem. Neověřuje otevírací heslo ani nestanovuje, zda lze načíst šifrovaný obsah. Naopak [PresentationInfo.check_password](https://reference.aspose.com/slides/cs/python-net/aspose.slides/presentationinfo/check_password/) ověřuje jen otevírací heslo. Pokud je již načtena úplná prezentace, poskytuje [ProtectionManager.check_write_protection](https://reference.aspose.com/slides/cs/python-net/aspose.slides/protectionmanager/check_write_protection/) ekvivalentní kontrolu ochrany zápisem prostřednictvím svého správce ochrany.

V produkčních aplikacích neukládejte hesla do logů ani je nezahrnujte do diagnostických zpráv. Vyhněte se zbytečným opakovaným pokusům o ověření a uchovávejte hesla v paměti jen po nezbytnou dobu.

{{% alert color="info" title="Viz také" %}}
- [Password-Protect Presentations](/slides/cs/python-net/password-protected-presentation/)
- [Read-Only Presentations](/slides/cs/python-net/read-only-presentation/)
- [Digital Signature in PowerPoint](/slides/cs/python-net/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Zda ochrana zápisem šifruje prezentaci?**

Ne. Omezuje úpravy, ale obsah prezentace zůstává dostupný pro načtení a prohlížení.

**Je heslo ochrany zápisem vyžadováno pro otevření prezentace?**

Ne. Pro načtení šifrovaného obsahu je vyžadováno pouze otevírací heslo.

**Může mít prezentace jak otevírací heslo, tak heslo ochrany zápisem?**

Ano. Otevírací heslo předáte přes možnosti načítání, aby se otevřela šifrovaná prezentace, a heslo ochrany zápisem ověříte samostatně, když je potřeba oprávnění k úpravám.