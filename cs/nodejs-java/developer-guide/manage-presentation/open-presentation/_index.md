---
title: Otevření prezentací v JavaScriptu
linktitle: Otevřít prezentaci
type: docs
weight: 20
url: /cs/nodejs-java/open-presentation/
keywords:
- otevřít PowerPoint
- otevřít prezentaci
- otevřít PPTX
- otevřít PPT
- otevřít ODP
- načíst prezentaci
- načíst PPTX
- načíst PPT
- načíst ODP
- chráněná prezentace
- velká prezentace
- externí zdroj
- binární objekt
- Node.js
- JavaScript
- Aspose.Slides
description: "Naučte se, jak v JavaScriptu otevřít prezentace PowerPoint a OpenDocument, zadávat otevírací hesla, řídit načítání zdrojů a snižovat využití paměti pomocí Aspose.Slides pro Node.js přes Java."
---
## **Úvod**

[Aspose.Slides for Node.js via Java](https://products.aspose.com/slides/cs/nodejs-java/) může načíst prezentace PowerPoint a OpenDocument ze souborů i proudů. Po načtení prezentace můžete prozkoumat její strukturu, upravit snímky, spravovat prostředky a uložit ji v původním nebo jiném podporovaném formátu.

Chování načítání lze přizpůsobit pomocí třídy [LoadOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/). Například můžete zadat otevírací heslo, umístit velké binární objekty mimo paměť Node.js, řídit externí zdroje nebo vynechat vložená binární data.

## **Otevření prezentací**

Pro otevření existující prezentace předáte její cestu k souboru konstruktoru [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/). Po použití uvolněte prezentaci, aby byly souborové handly, dočasná data a další prostředky rychle uvolněny.

Následující příklad v JavaScriptu ukazuje, jak otevřít prezentaci a získat počet snímků:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Otevření prezentací chráněných heslem**

Otevírací heslo šifruje obsah prezentace. Pro načtení celé prezentace předáte správné heslo metodě [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setPassword) a poskytnete možnosti konstruktoru [Presentation](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/). Načtení selže, pokud heslo chybí nebo je nesprávné.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setPassword("open_password");

const presentation = new slides.Presentation("encrypted-presentation.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Pro detekci hesla, validaci a šifrovací workflow viz [Password-Protect Presentations](/slides/cs/nodejs-java/password-protected-presentation/). Pokud byla šifrovaná prezentace úmyslně uložena s veřejnými vlastnostmi dokumentu, lze tyto vlastnosti přečíst bez hesla; viz [Manage Presentation Properties](/slides/cs/nodejs-java/presentation-properties/).

## **Otevření velkých prezentací**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#getBlobManagementOptions) vrací možnosti, které řídí, jak Aspose.Slides zachází s binárními velkými objekty, jako jsou obrázky, audio a video. Můžete udržet zdrojový soubor zamčený, povolit dočasné soubory a omezit množství BLOB dat uchovávaných v paměti.

Následující kód v JavaScriptu demonstruje načtení velké prezentace (například 2 GB):

```javascript
const slides = require("aspose.slides.via.java");

const filePath = "large-presentation.pptx";

const loadOptions = new slides.LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(slides.PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

const presentation = new slides.Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Poznámka" %}}
S [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentationlockingbehavior/#KeepLocked) zůstane zdrojový soubor zamčený až do uvolnění instance prezentace. Nepřesouvejte, nepřepisujte ani nesmažte zdrojový soubor, dokud je tato instance aktivní.

Aspose.Slides může během načítání zkopírovat obsah vstupního proudu. U velkých prezentací je proto obecně efektivnější použít cestu k souboru místo proudu. Další možnosti úložiště a správy paměti najdete v [Manage BLOBs](/slides/cs/nodejs-java/manage-blob/).
{{% /alert %}}

## **Řízení externích zdrojů**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setResourceLoadingCallback) přijímá implementaci [IResourceLoadingCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iresourceloadingcallback/). Callback může dodat náhradní data, přesměrovat zdroj, použít výchozí načítač nebo zdroj přeskočit. To je užitečné, když prezentace obsahují externí obrázky, které je třeba řešit podle specifických bezpečnostních nebo úložných pravidel aplikace.

```javascript
const slides = require("aspose.slides.via.java");
const fs = require("fs");
const java = require("java");

const imageLoadingHandler = java.newProxy("com.aspose.slides.IResourceLoadingCallback", {
    resourceLoading: function(args) {
        const isJpeg = args.getOriginalUri().toLowerCase().endsWith(".jpg");
        const approvedImagePath = "approved-image.jpg";
        if (!isJpeg || !fs.existsSync(approvedImagePath)) {
            return slides.ResourceLoadingAction.Skip;
        }

        try {
            const imageData = fs.readFileSync(approvedImagePath);
            args.setData(imageData);
            return slides.ResourceLoadingAction.UserProvided;
        } catch (error) {
            console.error("The approved replacement image could not be read.");
            return slides.ResourceLoadingAction.Skip;
        }
    }
});

const loadOptions = new slides.LoadOptions();
loadOptions.setResourceLoadingCallback(imageLoadingHandler);

const presentation = new slides.Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Načítání prezentací bez vložených binárních objektů**

Prezentace může obsahovat vložená binární data, která aplikace nepotřebuje nebo nechce uchovávat. Příklady zahrnují:

- VBA projekty, dostupné přes [Presentation.getVbaProject](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/presentation/#getVbaProject);
- vložená OLE data, dostupná přes [OleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/oleembeddeddatainfo/#getEmbeddedFileData);
- data ovládacích prvků ActiveX, dostupná přes [Control.getActiveXControlBinary](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/control/#getActiveXControlBinary).

Nastavte [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cs/nodejs-java/aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects) na `true`, aby se tato binární data při načítání odstranila. Uložte načtenou prezentaci, abyste zachovali vyčištěný výsledek.

Tato možnost snižuje riziko nežádoucích vložených nákladů, avšak nejde o úplný systém detekce malwaru či sanitizace obsahu.

```javascript
const slides = require("aspose.slides.via.java");

const loadOptions = new slides.LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

const presentation = new slides.Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", slides.SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Jak zjistím, že je soubor poškozený a nelze jej otevřít?**

Aspose.Slides během načítání vyhodí výjimku parsování nebo formátu. Zpracujte toto selhání odděleně od chyby nesprávného hesla, aby aplikace mohla přesně hlásit příčinu.

**Co se stane, když chybí požadovaná písma?**

Prezentace se stále načte, ale při vykreslování a exportu může dojít k substituci písem. Můžete [konfigurovat substituci písem](/slides/cs/nodejs-java/font-substitution/) nebo [poskytnout vlastní písma](/slides/cs/nodejs-java/custom-font/), aby byl výstup předvídatelnější.

**Načítá se při načtení prezentace také její vložená média?**

Vložené audio a video jsou dostupné prostřednictvím objektového modelu prezentace. Externí zdroje jsou řešeny podle nastaveného chování načítání zdrojů a mohou být nedostupné, pokud jejich umístění není přístupné.