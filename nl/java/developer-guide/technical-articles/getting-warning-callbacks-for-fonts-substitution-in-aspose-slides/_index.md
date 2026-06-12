---
title: Waarschuwingen ontvangen voor lettertype-substitutie
type: docs
weight: 90
url: /nl/java/getting-warning-callbacks-for-fonts-substitution-in-aspose-slides/
keywords:
- waarschuwingscallback
- lettertype-substitutie
- renderproces
- PowerPoint
- OpenDocument
- presentatie
- Java
- Aspose.Slides
description: "Leer hoe u waarschuwingen kunt ontvangen voor lettertype-substitutie in Aspose.Slides for Java en PowerPoint- en OpenDocument-presentaties nauwkeurig kunt weergeven."
---
## **Introductie**

Aspose.Slides for Java maakt het mogelijk om waarschuwings‑callbacks te ontvangen voor lettertype‑substitutie wanneer een vereist lettertype niet beschikbaar is op de machine tijdens het renderen. Deze callbacks helpen bij het diagnosticeren van problemen met ontbrekende of ontoegankelijke lettertypen.

## **Waarschuwingen inschakelen**

Aspose.Slides for Java biedt eenvoudige API's om waarschuwings‑callbacks te ontvangen bij het renderen van presentatieslides. Volg deze stappen om waarschuwings‑callbacks te configureren:

1. Maak een aangepaste callback‑klasse die de [IWarningCallback](https://reference.aspose.com/slides/nl/java/com.aspose.slides/iwarningcallback/) interface implementeert om waarschuwingen af te handelen.
1. Stel de waarschuwings‑callback in met behulp van optieklassen zoals [RenderingOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/renderingoptions/), [PdfOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/pdfoptions/), [HtmlOptions](https://reference.aspose.com/slides/nl/java/com.aspose.slides/htmloptions/), en andere.
1. Laad een presentatie die een lettertype gebruikt dat niet beschikbaar is op de doelmachine.
1. Genereer een miniatuur van een slide of exporteer de presentatie om het effect te observeren.

**Aangepaste waarschuwings‑callback‑klasse:**

```java
class FontWarningHandler implements IWarningCallback {
    public int warning(IWarningInfo warning) {
        if (warning.getWarningType() == WarningType.DataLoss) {
            System.out.println(warning.getDescription());
        }
        return ReturnAction.Continue;
    }
}

// Voorbeeldoutput:
//
// Lettertype zal worden vervangen van XYZ naar {Calibri,Cambria Math,MS Gothic,Gulim,Arial Unicode,SimSun,Segoe UI Symbol}}
```

**Miniatuur van een slide genereren:**

```java
// Stel een waarschuwingscallback in om waarschuwingen met betrekking tot lettertypen af te handelen tijdens het renderen van slides.
RenderingOptions options = new RenderingOptions();
options.setWarningCallback(new FontWarningHandler());

// Laad de presentatie vanaf het opgegeven bestandspad.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Genereer een miniatuurafbeelding voor elke slide in de presentatie.
    for (ISlide slide : presentation.getSlides()) {
        // Verkrijg de miniatuurafbeelding van de slide met behulp van de opgegeven renderopties.
        IImage image = slide.getImage(options);
        // ...

        image.dispose();
    }
}
finally {
    presentation.dispose();
}
```

**Exporteren naar PDF‑formaat:**

```java
// Stel een waarschuwingscallback in om waarschuwingen met betrekking tot lettertypen af te handelen tijdens PDF-export.
SaveOptions options = new PdfOptions();
options.setWarningCallback(new FontWarningHandler());

// Laad de presentatie vanaf het opgegeven bestandspad.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Exporteer de presentatie als PDF.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Pdf, options);
    // ...
}
finally {
    presentation.dispose();    
}
```

**Exporteren naar HTML‑formaat:**

```java
// Stel een waarschuwingscallback in om waarschuwingen met betrekking tot lettertypen af te handelen tijdens HTML-export.
SaveOptions options = new HtmlOptions();
options.setWarningCallback(new FontWarningHandler());

// Laad de presentatie vanaf het opgegeven bestandspad.
Presentation presentation = new Presentation("sample.pptx");
try {
    // Exporteer de presentatie in HTML-indeling.
    ByteArrayOutputStream stream = new ByteArrayOutputStream();
    presentation.save(stream, SaveFormat.Html, options);
    // ...
}
finally {
    presentation.dispose();
}
```