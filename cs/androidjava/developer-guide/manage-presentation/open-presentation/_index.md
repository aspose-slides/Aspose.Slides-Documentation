---
title: Otevření prezentací na Androidu
linktitle: Otevřít prezentaci
type: docs
weight: 20
url: /cs/androidjava/open-presentation/
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
- externí prostředek
- binární objekt
- Android
- Java
- Aspose.Slides
description: "Naučte se, jak na Androidu otevírat prezentace PowerPoint a OpenDocument, zadávat otevírací hesla, řídit načítání prostředků a snižovat využití paměti pomocí Aspose.Slides pro Android via Java."
---
## **Úvod**

[Aspose.Slides for Android via Java](https://products.aspose.com/slides/cs/androidjava/) může načíst prezentace PowerPoint a OpenDocument ze souborů a proudů. Po načtení prezentace můžete prozkoumat její strukturu, upravovat snímky, spravovat prostředky a uložit ji v původním nebo jiném podporovaném formátu.

Chování načítání lze přizpůsobit pomocí třídy [LoadOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/). Například můžete zadat otevírací heslo, uchovávat velké binární objekty mimo haldu Java, řídit externí prostředky nebo vynechat vložená binární data.

## **Otevření prezentací**

Po načtení souboru nebo proudu můžete [zjistit jeho původní formát prezentace](/slides/cs/androidjava/detect-presentation-source-format/), abyste si vybrali, jak aplikace bude s prezentací pracovat.

Pro otevření existující prezentace předáte její cestu k souboru do konstruktoru [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/). Po použití uvolněte instanci prezentace, aby byly souborové handle, dočasná data a další prostředky okamžitě uvolněny.

Následující příklad v jazyce Java ukazuje, jak otevřít prezentaci a získat počet snímků:

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

Otevírací heslo šifruje obsah prezentace. Pro načtení celé prezentace předáte správné heslo metodě [LoadOptions.setPassword](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/#setPassword-java.lang.String-) a předáte možnosti konstruktoru [Presentation](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentation/). Načtení selže, pokud heslo chybí nebo je nesprávné.

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

Pro detekci hesla, jeho ověření a šifrovací pracovní postupy viz [Password-Protect Presentations](/slides/cs/androidjava/password-protected-presentation/). Pokud byla šifrovaná prezentace úmyslně uložena s veřejnými vlastnostmi dokumentu, lze tyto vlastnosti číst bez hesla; viz [Manage Presentation Properties](/slides/cs/androidjava/presentation-properties/).

## **Otevření velkých prezentací**

[LoadOptions.getBlobManagementOptions](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/#getBlobManagementOptions--) vrací možnosti, které řídí, jak Aspose.Slides zachází s binárními velkými objekty, jako jsou obrázky, audio a video. Můžete nechat zdrojový soubor zamčený, povolit dočasné soubory a omezit množství BLOB dat uchovávaných v paměti.

Následující kód v jazyce Java demonstruje načtení velké prezentace (například 2 GB):

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
S pomocí [PresentationLockingBehavior.KeepLocked](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/presentationlockingbehavior/#KeepLocked) zůstane zdrojový soubor zamčený, dokud není instance prezentace uvolněna. Nepřesouvejte, nepřepisujte ani nesmažte zdrojový soubor, dokud je tato instance aktivní.

Aspose.Slides může při načítání zkopírovat obsah vstupního proudu. U velkých prezentací je proto cesta k souboru obecně efektivnější než proud. Další možnosti úložiště a správy paměti najdete v [Manage BLOBs](/slides/cs/androidjava/manage-blob/).
{{% /alert %}}

## **Řízení externích prostředků**

[LoadOptions.setResourceLoadingCallback](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/#setResourceLoadingCallback-com.aspose.slides.IResourceLoadingCallback-) přijímá implementaci rozhraní [IResourceLoadingCallback](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/iresourceloadingcallback/). Callback může poskytnout náhradní data, přesměrovat prostředek, použít výchozí načítač nebo prostředek přeskočit. To je užitečné, když prezentace obsahují externí obrázky, které je třeba vyřešit podle specifických bezpečnostních nebo úložných pravidel aplikace.

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
- projekty VBA, dostupné pomocí [IPresentation.getVbaProject](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ipresentation/#getVbaProject--);
- vložená data OLE, dostupná pomocí [IOleEmbeddedDataInfo.getEmbeddedFileData](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/ioleembeddeddatainfo/#getEmbeddedFileData--);
- data ovládacích prvků ActiveX, dostupná pomocí [IControl.getActiveXControlBinary](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/icontrol/#getActiveXControlBinary--).

Nastavte [LoadOptions.setDeleteEmbeddedBinaryObjects](https://reference.aspose.com/slides/cs/androidjava/com.aspose.slides/loadoptions/#setDeleteEmbeddedBinaryObjects-boolean-) na `true`, aby se tato binární data při načítání odstranila. Uložte načtenou prezentaci, aby se zachoval vyčištěný výsledek.

Tato volba snižuje riziko nechtěných vložených nákladů, avšak nejedná se o kompletní systém detekce škodlivého softwaru či sanitizace obsahu.

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

**Jak poznám, že soubor je poškozený a nelze jej otevřít?**

Aspose.Slides během načítání vyhodí výjimku parsování nebo formátu. Tento selhání ošetřete odděleně od chyby nesprávného hesla, aby aplikace mohla přesně oznámit příčinu.

**Co se stane, pokud chybí požadovaná písma?**

Prezentace se může i nadále načíst, ale při vykreslování a exportu mohou být písma nahrazena. Můžete [konfigurovat substituci písma](/slides/cs/androidjava/font-substitution/) nebo [poskytnout vlastní písma](/slides/cs/androidjava/custom-font/), aby byl výstup předvídatelnější.

**Načítá se při načítání prezentace také její vložená média?**

Vložený audio a video se zpřístupní prostřednictvím objektového modelu prezentace. Externí prostředky jsou řešeny podle nastaveného chování načítání prostředků a mohou být nedostupné, pokud nelze jejich umístění přistupovat.