---
title: Prezentace chráněné proti zápisu v JavaScriptu
linktitle: Ochrana proti zápisu
type: docs
weight: 25
url: /cs/nodejs-java/write-protected-presentation/
keywords:
- ochrana proti zápisu
- ochrana proti zápisu PowerPoint
- heslo pro úpravy
- omezení úprav prezentace
- odstranění ochrany proti zápisu
- ověření hesla pro úpravy
- PowerPoint
- prezentace
- Node.js
- JavaScript
- Aspose.Slides
description: "Nastavujte, detekujte, ověřujte a odstraňujte hesla ochrany proti zápisu v PowerPoint PPT a PPTX prezentacích pomocí Aspose.Slides pro Node.js prostřednictvím Javy."
---
## **Úvod**

Heslo pro ochranu proti zápisu omezuje úpravy prezentace, ale nešifruje její obsah. Uživatelé mohou načíst a zobrazit prezentaci chráněnou proti zápisu bez hesla. V závislosti na aplikaci mohou také upravit obsah a uložit jej pod jiným názvem, takže ochrana proti zápisu by neměla být považována za mechanismus důvěrnosti.

Otevírací heslo slouží k jinému účelu: šifruje prezentaci a je vyžadováno pro načtení jejího obsahu. Pro šifrování prezentace nebo ověření otevíracího hesla viz [Prezentace chráněné heslem](/slides/cs/nodejs-java/password-protected-presentation/).

Postupy v tomto článku platí pro prezentace PPT i PPTX. Příklady používají soubory PPTX; při ukládání do PPT použijte příponu `.ppt` a odpovídající formát ukládání PPT.

## **Nastavení ochrany proti zápisu u prezentace**

K nastavení hesla pro úpravu prezentace použijte [ProtectionManager.setWriteProtection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/protectionmanager/#setWriteProtection). Uložení prezentace zachová nastavení ochrany.

Následující příklad nastavuje ochranu proti zápisu u PPTX prezentace:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("pres.pptx");
try {
    presentation.getProtectionManager().setWriteProtection("modify_password");
    presentation.save("write-protected-pres.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Načtení prezentace chráněné proti zápisu**

Protože ochrana proti zápisu nešifruje obsah prezentace, není pro načtení prezentace požadováno žádné heslo. Heslo je relevantní pouze při ověřování oprávnění k úpravě chráněné prezentace.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Do not předávat heslo ochrany proti zápisu metodě [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setPassword). Tato metoda přijímá otevírací heslo pro šifrovaný obsah. Pokud má prezentace oba typy ochrany, zadejte otevírací heslo pro její načtení a heslo ochrany proti zápisu řešte samostatně.

## **Odstranění ochrany proti zápisu z prezentace**

K odstranění omezení úprav použijte [ProtectionManager.removeWriteProtection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/protectionmanager/#removeWriteProtection), poté prezentaci uložte.

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("write-protected-pres.pptx");
try {
    presentation.getProtectionManager().removeWriteProtection();
    presentation.save("write-protection-removed.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Kontrola, zda je prezentace chráněna proti zápisu**

Pro prohlédnutí souboru bez vytvoření kompletní instance [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/) zavolejte [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfo) a zkontrolujte [PresentationInfo.isWriteProtected](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/#isWriteProtected). Metoda používá [NullableBool](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/nullablebool/) a vrací `NullableBool.True`, pokud je detekována ochrana proti zápisu.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() === slides.NullableBool.True) {
    console.log("The presentation is write protected.");
} else {
    console.log("Write protection was not detected.");
}
```

Metoda založená na proudu [PresentationFactory.getPresentationInfoFromStream](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationfactory/#getPresentationInfoFromStream) poskytuje stejné informace pro prezentaci předanou jako čitelný proud Node.js.

## **Ověření hesla ochrany proti zápisu**

K ověření hesla pro úpravy bez načtení kompletní prezentace použijte [PresentationInfo.checkWriteProtection](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationinfo/#checkWriteProtection). Nejprve zkontrolujte [PresentationInfo.isWriteProtected], aby aplikace požadovala nebo ověřovala heslo pouze v případě, že je přítomna ochrana proti zápisu.

```javascript
const slides = require("aspose.slides.via.java");

const presentationInfo = slides.PresentationFactory.getInstance().getPresentationInfo("write-protected-pres.pptx");

if (presentationInfo.isWriteProtected() !== slides.NullableBool.True) {
    console.log("The presentation is not write protected.");
} else if (presentationInfo.checkWriteProtection("modify_password")) {
    console.log("The write-protection password is correct.");
} else {
    console.log("The write-protection password is incorrect.");
}
```

[PresentationInfo.checkWriteProtection] ověřuje pouze heslo ochrany proti zápisu. Neověřuje otevírací heslo ani neurčuje, zda lze načíst šifrovaný obsah. Naopak, [PresentationInfo.checkPassword] ověřuje pouze otevírací heslo. Pokud je již kompletní prezentace načtena, [ProtectionManager.checkWriteProtection] poskytuje ekvivalentní kontrolu ochrany proti zápisu prostřednictvím svého správce ochrany.

V produkčních aplikacích neukládejte hesla do protokolů ani je nezahrnujte do diagnostických zpráv. Vyhněte se zbytečným opakovaným pokusům o ověření a uchovávejte hesla v paměti pouze po dobu, kdy jsou potřebná.

{{% alert color="info" title="Viz také" %}}
- [Prezentace chráněné heslem](/slides/cs/nodejs-java/password-protected-presentation/)
- [Prezentace pouze pro čtení](/slides/cs/nodejs-java/read-only-presentation/)
- [Digitální podpis v PowerPointu](/slides/cs/nodejs-java/digital-signature-in-powerpoint/)
{{% /alert %}}

## **Často kladené otázky**

**Šifruje ochrana proti zápisu prezentaci?**

Ne. Omezuje úpravy, ale ponechává obsah prezentace dostupný pro načtení a zobrazení.

**Je heslo ochrany proti zápisu vyžadováno pro otevření prezentace?**

Ne. Pro načtení šifrovaného obsahu prezentace je vyžadováno pouze otevírací heslo.

**Může mít prezentace jak otevírací heslo, tak heslo ochrany proti zápisu?**

Ano. Otevírací heslo předáte prostřednictvím možností načítání pro otevření šifrované prezentace a heslo ochrany proti zápisu ověříte samostatně, když je vyžadováno oprávnění k úpravě.