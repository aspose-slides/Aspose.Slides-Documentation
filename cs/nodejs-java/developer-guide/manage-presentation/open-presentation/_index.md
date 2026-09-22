---
title: Otevřít prezentace v JavaScriptu
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
description: "Zjistěte, jak v JavaScriptu otevřít prezentace PowerPoint a OpenDocument, zadat otevírací hesla, řídit načítání zdrojů a snížit využití paměti pomocí Aspose.Slides pro Node.js přes Javu."
---
## **Introduction**

Aspose.Slides pro Node.js prostřednictvím Javy dokáže načíst prezentace PowerPoint a OpenDocument ze souborů i proudů. Po načtení prezentace můžete prozkoumat její strukturu, upravovat snímky, spravovat zdroje a uložit ji v původním nebo jiném podporovaném formátu.

Chování načítání lze přizpůsobit pomocí třídy LoadOptions. Například můžete zadat otevírací heslo, uchovávat velké binární objekty mimo paměť Node.js, řídit externí zdroje nebo vynechat vložená binární data.

## **Open Presentations**

Po načtení souboru nebo proudu můžete [zjistit jeho původní formát prezentace](/slides/cs/nodejs-java/detect-presentation-source-format/), abyste si vybrali, jak aplikace bude s souborem pracovat.

Chcete-li otevřít existující prezentaci, předáte její cestu k souboru konstruktoru Presentation. Po použití prezentaci uvolněte, aby byly souborové handly, dočasná data a další zdroje okamžitě uvolněny.

Následující JavaScriptový příklad ukazuje, jak otevřít prezentaci a získat počet snímků:

```javascript
const slides = require("aspose.slides.via.java");

const presentation = new slides.Presentation("sample.pptx");
try {
    console.log("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Open Password-Protected Presentations**

Otevírací heslo šifruje obsah prezentace. Pro načtení celé prezentace předáte správné heslo metodě LoadOptions.setPassword a poskytnete tyto možnosti konstruktoru Presentation. Načítání selže, pokud heslo chybí nebo je nesprávné.

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

Pro detekci hesla, ověřování a šifrovací pracovní postupy viz Password-Protect Presentations. Pokud byla šifrovaná prezentace úmyslně uložena s veřejnými vlastnostmi dokumentu, lze tyto vlastnosti načíst bez hesla; viz Manage Presentation Properties.

## **Open Large Presentations**

LoadOptions.getBlobManagementOptions vrací možnosti, které řídí, jak Aspose.Slides zachází s binárními velkými objekty, jako jsou obrázky, audio a video. Můžete ponechat zdrojový soubor uzamčený, povolit dočasné soubory a omezit množství BLOB dat uchovávaných v paměti.

Následující JavaScriptový kód ukazuje načtení velké prezentace (například 2 GB):

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

{{% alert color="info" title="Note" %}}
S PresentationLockingBehavior.KeepLocked zůstává zdrojový soubor uzamčený, dokud není instance Presentation uvolněna. Nezahrnujte, nepřepisujte ani neodstraňujte zdrojový soubor, dokud je tato instance aktivní.

Aspose.Slides může při načítání zkopírovat obsah vstupního proudu. U velkých prezentací je proto cesta k souboru obecně efektivnější než proud. Viz Manage BLOBs pro další možnosti úložiště a správy paměti.
{{% /alert %}}

## **Control External Resources**

LoadOptions.setResourceLoadingCallback přijímá implementaci IResourceLoadingCallback. Callback může poskytnout náhradní data, přesměrovat zdroj, použít výchozí načítač nebo zdroj přeskočit. To je užitečné, když prezentace obsahují externí obrázky, které je nutné vyřešit podle specifických bezpečnostních či úložných pravidel aplikace.

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

## **Load Presentations without Embedded Binary Objects**

Prezentace může obsahovat vložená binární data, která aplikace nepotřebuje nebo nechce zachovat. Příklady zahrnují:

- VBA projekty, dostupné přes Presentation.getVbaProject;
- vložená data OLE, dostupná přes OleEmbeddedDataInfo.getEmbeddedFileData;
- data ActiveX ovládacích prvků, dostupná přes Control.getActiveXControlBinary.

Nastavte LoadOptions.setDeleteEmbeddedBinaryObjects na `true`, aby byla tato binární data při načítání odstraněna. Uložte načtenou prezentaci, aby byl sanitizovaný výsledek zachován.

Tato volba snižuje riziko nežádoucích vložených nákladů, avšak nejde o kompletní systém pro detekci malwaru nebo sanitaci obsahu.

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

## **FAQ**

**Jak zjistím, že je soubor poškozený a nelze jej otevřít?**

Aspose.Slides během načítání vyhodí výjimku parsování nebo formátu. Tuto chybu ošetřete odděleně od chyby nesprávného hesla, aby aplikace mohla přesně nahlásit příčinu.

**Co se stane, pokud chybí požadované fonty?**

Prezentace se i přesto načte, ale při vykreslování a exportu mohou být fonty nahrazeny. Můžete [configure font substitution](/slides/cs/nodejs-java/font-substitution/) nebo [provide custom fonts](/slides/cs/nodejs-java/custom-font/) pro předvídatelnější výstup.

**Načítá se při načítání prezentace také její vložená média?**

Vložené audio a video jsou dostupné prostřednictvím objektového modelu prezentace. Externí zdroje jsou řešeny podle nastaveného chování načítání zdrojů a mohou být nedostupné, pokud jejich umístění není přístupné.