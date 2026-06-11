---
title: Få varningsåteranrop för teckensnittssubstitution
type: docs
weight: 90
url: /sv/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- varningsåteranrop
- teckensnittssubstitution
- renderingsprocess
- PowerPoint
- OpenDocument
- presentation
- Java
- Aspose.Slides
description: "Lär dig att hämta varningsåteranrop för teckensnittssubstitution i Aspose.Slides för Java och visa PowerPoint- och OpenDocument-presentationer exakt."
---
## **Introduktion**

Aspose.Slides for Java låter dig ta emot varningsåteranrop för teckensnittssubstitution när ett obligatoriskt teckensnitt inte är tillgängligt på datorn under rendering. Dessa återanrop hjälper till att diagnostisera problem med saknade eller otillgängliga teckensnitt.

## **Aktivera varningsåteranrop**

Aspose.Slides for Java erbjuder enkla API:er för att ta emot varningsåteranrop vid rendering av presentationsbilder. Följ dessa steg för att konfigurera varningsåteranrop:

1. Skapa en anpassad återanropsklass som implementerar gränssnittet [IWarningCallback](https://reference.aspose.com/slides/sv/java/com.aspose.slides/iwarningcallback/) för att hantera varningar.
1. Ställ in varningsåteranropet med hjälp av alternativklasser såsom [RenderingOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/sv/java/com.aspose.slides/htmloptions/) och andra.
1. Läs in en presentation som använder ett teckensnitt som inte är tillgängligt på måldatorn.
1. Generera en bildminiatyr eller exportera presentationen för att observera resultatet.

**Anpassad varningsåteranropsklass:**

```java
class FontWarningHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss) {
            System.out.println(warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

// Exempelutdata:
//
// Teckensnittet kommer att ersättas från XYZ till {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Generera en bildminiatyr:**

```java
// Ställ in ett varningsåteranrop för att hantera teckensnittsrelaterade varningar under bildrendering.
RenderingOptions options = new RenderingOptions();
options.setWarningCallback(new FontWarningHandler());

// Läs in presentationen från den angivna filsökvägen.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Generera en miniatyrbild för varje bild i presentationen.
    for (ISlide slide : presentation.getSlides()) {
        // Hämta bildens miniatyrbild med de angivna renderingsalternativen.
        IImage image = slide.getImage(options);
        // ...

        image.dispose();
    }
}
finally {
    presentation.dispose();
}
```

**Exportera till PDF-format:**

```java
// Ställ in ett varningsåteranrop för att hantera teckensnittsrelaterade varningar under PDF-export.
SaveOptions options = new PdfOptions();
options.setWarningCallback(new FontWarningHandler());

// Läs in presentationen från den angivna filsökvägen.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Exportera presentationen som PDF.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Pdf, options);
    // ...
}
finally {
    presentation.dispose();    
}
```

**Exportera till HTML-format:**

```java
// Ställ in ett varningsåteranrop för att hantera teckensnittsrelaterade varningar under HTML-export.
SaveOptions options = new HtmlOptions();
options.setWarningCallback(new FontWarningHandler());

// Läs in presentationen från den angivna filsökvägen.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Exportera presentationen i HTML-format.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Html, options);
    // ...
}
finally {
    presentation.dispose();
}
```