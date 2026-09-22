---
title: Otevření prezentací v Javě
linktitle: Otevřít prezentaci
type: docs
weight: 20
url: /cs/java/open-presentation/
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
- Java
- Aspose.Slides
description: "Naučte se, jak v Javě otevírat prezentace PowerPoint a OpenDocument, zadávat otevírací hesla, řídit načítání zdrojů a snižovat využití paměti pomocí Aspose.Slides pro Javu."
---
## **Úvod**

[Aspose.Slides for Java](https://products.aspose.com/slides/cs/java/) může načítat prezentace PowerPoint a OpenDocument ze souborů a proudů. Po načtení prezentace můžete prozkoumat její strukturu, upravovat snímky, spravovat zdroje a uložit ji v původním nebo jiném podporovaném formátu.

Chování načítání lze přizpůsobit pomocí třídy [LoadOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/). Například můžete zadat otevírací heslo, udržovat velké binární objekty mimo paměť haldy Java, řídit externí zdroje nebo vynechat vložená binární data.

## **Otevření prezentací**

Po načtení souboru nebo proudu můžete [zjistit jeho původní formát prezentace](/slides/cs/java/detect-presentation-source-format/), abyste si vybrali, jak aplikace s ním bude pracovat.

Chcete-li otevřít existující prezentaci, předávejte její cestu k souboru konstruktoru [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/). Po použití uvolněte prezentaci, aby byly soubory, dočasná data a další prostředky rychle uvolněny.

Následující ukázka v Javě ukazuje, jak otevřít prezentaci a získat počet snímků:

```java
import com.aspose.slides.Presentation;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Otevření prezentací chráněných heslem**

Otevírací heslo šifruje obsah prezentace. Pro načtení celé prezentace předáte správné heslo metodě [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) a poskytnete možnosti konstruktoru [Presentation](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentation/). Načtení selže, pokud heslo chybí nebo není správné.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setPassword("open_password");

Presentation presentation = new Presentation("encrypted-presentation.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

Pro detekci hesla, ověření a šifrovací pracovní toky viz [Password-Protect Presentations](/slides/cs/java/password-protected-presentation/). Pokud byla šifrovaná prezentace úmyslně uložena s veřejnými vlastnostmi dokumentu, lze tyto vlastnosti přečíst bez hesla; viz [Manage Presentation Properties](/slides/cs/java/presentation-properties/).

## **Otevření velkých prezentací**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#getBlobManagementOptions--) vrací možnosti, které řídí, jak Aspose.Slides zachází s velkými binárními objekty, jako jsou obrázky, audio a video. Můžete nechat zdrojový soubor uzamčený, povolit dočasné soubory a omezit množství BLOB dat uchovávaných v paměti.

Následující kód v Javě ukazuje načítání velké prezentace (například 2 GB):

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.PresentationLockingBehavior;
import com.aspose.slides.SaveFormat;

final String filePath = "large-presentation.pptx";

LoadOptions loadOptions = new LoadOptions();
loadOptions.getBlobManagementOptions().setPresentationLockingBehavior(PresentationLockingBehavior.KeepLocked);
loadOptions.getBlobManagementOptions().setTemporaryFilesAllowed(true);
loadOptions.getBlobManagementOptions().setMaxBlobsBytesInMemory(10 * 1024 * 1024);

Presentation presentation = new Presentation(filePath, loadOptions);
try {
    presentation.getSlides().get_Item(0).setName("Large presentation");
    presentation.save("large-presentation-copy.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

{{% alert color="info" title="Note" %}}
S [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/cs/java/com.aspose.slides/presentationlockingbehavior/#KeepLocked) zůstává zdrojový soubor uzamčený, dokud není instance prezentace uvolněna. Neprovádějte přesun, přepsání ani odstranění zdrojového souboru, dokud je tato instance aktivní.

Aspose.Slides může během načítání zkopírovat obsah vstupního proudu. Pro velké prezentace je tedy cesta k souboru obecně efektivnější než proud. Viz [Manage BLOBs](/slides/cs/java/manage-blob/) pro další možnosti úložiště a správy paměti.
{{% /alert %}}

## **Řízení externích zdrojů**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) přijímá implementaci [IResourceLoadingCallback](https://reference.aspose.com/slides/cs/java/com.aspose.slides/iresourceloadingcallback/). Callback může poskytnout náhradní data, přesměrovat zdroj, použít výchozí načítač nebo zdroj přeskočit. To je užitečné, když prezentace obsahují externí obrázky, které je nutné vyřešit podle specifických bezpečnostních nebo úložných pravidel aplikace.

```java
import com.aspose.slides.IResourceLoadingArgs;
import com.aspose.slides.IResourceLoadingCallback;
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.ResourceLoadingAction;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Path;
import java.nio.file.Paths;
import java.util.Locale;

class ImageLoadingHandler implements IResourceLoadingCallback {
    public int resourceLoading(IResourceLoadingArgs args) {
        boolean isJpeg = args.getOriginalUri().toLowerCase(Locale.ROOT).endsWith(".jpg");
        Path approvedImagePath = Paths.get("approved-image.jpg");
        if (!isJpeg || !Files.exists(approvedImagePath)) {
            return ResourceLoadingAction.Skip;
        }

        try {
            byte[] imageData = Files.readAllBytes(approvedImagePath);
            args.setData(imageData);
            return ResourceLoadingAction.UserProvided;
        } catch (IOException exception) {
            System.err.println("The approved replacement image could not be read.");
            return ResourceLoadingAction.Skip;
        }
    }
}

LoadOptions loadOptions = new LoadOptions();
loadOptions.setResourceLoadingCallback(new ImageLoadingHandler());

Presentation presentation = new Presentation("presentation-with-external-images.pptx", loadOptions);
try {
    System.out.println("Slide count: " + presentation.getSlides().size());
} finally {
    presentation.dispose();
}
```

## **Načtení prezentací bez vložených binárních objektů**

Prezentace může obsahovat vložená binární data, která aplikace nepotřebuje nebo nechce zachovat. Příklady zahrnují:

- VBA projekty, dostupné přes [IPresentation.getVbaProject](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ipresentation/#getVbaProject--);
- vložená OLE data, dostupná přes [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/cs/java/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- data ActiveX ovládacích prvků, dostupná přes [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/cs/java/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Nastavte [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cs/java/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) na `true`, abyste při načítání odstranili tato binární data. Uložte načtenou prezentaci, aby se zachoval vyčištěný výsledek.

Tato volba snižuje riziko nechtěných vložených nákladů, avšak nejde o kompletní systém detekce škodlivého softwaru ani o čištění obsahu.

```java
import com.aspose.slides.LoadOptions;
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

LoadOptions loadOptions = new LoadOptions();
loadOptions.setDeleteEmbeddedBinaryObjects(true);

Presentation presentation = new Presentation("presentation-with-embedded-data.pptx", loadOptions);
try {
    presentation.save("presentation-without-embedded-data.pptx", SaveFormat.Pptx);
} finally {
    presentation.dispose();
}
```

## **Často kladené otázky**

**Jak zjistím, že soubor je poškozený a nelze jej otevřít?**

Aspose.Slides během načítání vyvolá výjimku při parsování nebo formátu. Tento typ selhání je potřeba ošetřit odděleně od chyby nesprávného hesla, aby aplikace mohla přesně nahlásit příčinu.

**Co se stane, pokud chybí požadovaná písma?**

Prezentace může být i přesto načtena, ale během vykreslování a exportu může dojít k substituci písem. Můžete [nastavit substituci písem](/slides/cs/java/font-substitution/) nebo [poskytnout vlastní písma](/slides/cs/java/custom-font/), aby byl výstup předvídatelnější.

**Načte se při načítání prezentace také její vložená média?**

Vložený audio a video obsah jsou dostupné prostřednictvím objektového modelu prezentace. Externí zdroje jsou řešeny podle nastaveného chování načítání zdrojů a mohou být nedostupné, pokud není možné přistoupit k jejich umístění.