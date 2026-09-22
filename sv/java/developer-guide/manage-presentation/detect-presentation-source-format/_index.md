---
title: Bestäm det ursprungliga presentationsformatet i Java
linktitle: Källformat
type: docs
weight: 35
url: /sv/java/detect-presentation-source-format/
keywords:
- källformat
- detektera presentationsformat
- PowerPoint
- OpenDocument
- presentation
- PPT
- PPTX
- Java
- Aspose.Slides
description: "Läs det ursprungliga formatet för en inläst presentation i Java med Aspose.Slides för Java, jämför detekterings-API:er och hantera filer, strömmar och äldre format."
---
## **Översikt**

Efter att en presentation har lästs in, anropa metoden [Presentation.getSourceFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getSourceFormat--) för att bestämma dess ursprungliga format. Metoden finns också tillgänglig via [IPresentation.getSourceFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentation/#getSourceFormat--). Använd den när efterföljande bearbetning beror på formatet som den aktuella instansen laddades från.

Källformatet är skiljt från det [SaveFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/saveformat/) som väljs för en utdatafil. Att spara till ett annat format ändrar inte källformatet för den befintliga instansen.

## **Läs källformatet för en fil**

Det här exemplet kräver en befintlig fil `sample.pptx`. Den laddar filen och väljer en applikationsbehandlingspolicy med [Presentation.getSourceFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getSourceFormat--), istället för filnamnet. Ändra indata‑sökvägen för att prova andra format. Exemplet skriver ut den valda policyn; ersätt meddelandena med din applikationslogik.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
        case SourceFormat.Pps:
        case SourceFormat.Pot:
            System.out.println("Use the legacy PowerPoint processing policy.");
            break;
        case SourceFormat.Pptx:
            System.out.println("Use the standard PPTX processing policy.");
            break;
        default:
            System.out.println("Use the general policy for source format " + presentation.getSourceFormat() + ".");
            break;
    }
} finally {
    presentation.dispose();
}
```

## **Känn igen de stödda värdena**

Klassen [SourceFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/sourceformat/) definierar heltalskonstanter som särskiljer följande presentationsformat. Extensionerna nedan är konventionella extensioner, inte en återuppbyggnad av det ursprungliga filnamnet.

| SourceFormat‑värde | Filändelse | Format |
| --- | --- | --- |
| `Ppt` | `.ppt` | PowerPoint‑presentation 97–2003 |
| `Pptx` | `.pptx` | Office Open XML‑presentation |
| `Pptm` | `.pptm` | Makroaktiverad Office Open XML‑presentation |
| `Pps` | `.pps` | PowerPoint‑bildspel 97–2003 |
| `Ppsx` | `.ppsx` | Office Open XML‑bildspel |
| `Ppsm` | `.ppsm` | Makroaktiverat Office Open XML‑bildspel |
| `Pot` | `.pot` | PowerPoint‑mall 97–2003 |
| `Potx` | `.potx` | Office Open XML‑mall |
| `Potm` | `.potm` | Makroaktiverad Office Open XML‑mall |
| `Odp` | `.odp` | OpenDocument‑presentation |
| `Otp` | `.otp` | OpenDocument‑presentationmall |
| `Fodp` | `.fodp` | Flat XML ODF‑presentation |
| `Xml` | `.xml` | PowerPoint‑XML‑presentation |

## **Läs källformatet för en ström**

Det här exemplet kräver en befintlig fil `sample.pps`. Att läsa dess byte till ett minnesström modellerar indata som mottagits utan ett filnamn, t.ex. ett databervärde eller en uppladdad byte‑array. Konstruktoren för [Presentation](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/) tar bara emot strömmen.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

try {
    byte[] bytes = Files.readAllBytes(Paths.get("sample.pps"));
    try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
        Presentation presentation = new Presentation(stream);
        try {
            System.out.println("Source format: " + presentation.getSourceFormat());
        } finally {
            presentation.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read the presentation: " + exception.getMessage());
}
```

PPT, PPS och POT använder samma underliggande binära format. Vid inläsning via filsökväg kan filändelsen hjälpa till att särskilja ett bildspel eller en mall. Utan ett filnamn kan äldre PPS‑ och POT‑innehåll rapporteras som `SourceFormat.Ppt`; PPS‑exemplet ovan skriver ut heltalsvärdet för `SourceFormat.Ppt`.

Om din applikation måste bevara skillnaden, behåll det ursprungliga filnamnet eller metadata för undertyp separat. En filändelse är ett användbart tipshint för dessa äldre undertyper, men bör inte vara det enda underlaget för att identifiera godtyckligt presentationsinnehåll.

## **Jämför detektering före och efter inläsning**

Använd [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) och [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/ipresentationinfo/#getLoadFormat--) när du behöver inspektera en fil innan hela presentationsobjektmodellen har lästs in. Använd [Presentation.getSourceFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getSourceFormat--) när instansen redan finns.

Det här exemplet kräver `sample.pptx` och skriver ut heltalsvärdena för `LoadFormat.Pptx` respektive `SourceFormat.Pptx`. I produktion, välj det API som passar ditt bearbetningssteg; en redan inläst presentation behöver inte en andra inspektion enbart för att få dess källformat.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.IPresentationInfo;
import com.aspose.slides.PresentationFactory;

String path = "sample.pptx";
IPresentationInfo information = PresentationFactory.getInstance().getPresentationInfo(path);
System.out.println("Before loading: " + information.getLoadFormat());

Presentation presentation = new Presentation(path);
try {
    System.out.println("After loading: " + presentation.getSourceFormat());
} finally {
    presentation.dispose();
}
```

Resultaten använder konstanter från olika klasser: [LoadFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/loadformat/) och [SourceFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/sourceformat/). Jämför inte deras numeriska värden eller anta att alla format har identiska detekteringsresultat. PowerPoint‑XML kan rapporteras som `LoadFormat.Unknown` före inläsning och `SourceFormat.Xml` efter inläsning.

## **Håll käll- och utdataformat separata**

Det här exemplet kräver `sample.pptx` och skriver `converted.odp`. Det skriver ut heltalsvärdet för `SourceFormat.Pptx` både före och efter att den ursprungliga instansen sparats. Endast den nya instansen som lästs in från ODP‑utdata rapporterar `Odp`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    System.out.println("Before saving: " + presentation.getSourceFormat());

    presentation.save("converted.odp", SaveFormat.Odp);
    System.out.println("After saving: " + presentation.getSourceFormat());

    Presentation reopened = new Presentation("converted.odp");
    try {
        System.out.println("Reopened output: " + reopened.getSourceFormat());
    } finally {
        reopened.dispose();
    }
} finally {
    presentation.dispose();
}
```

En presentation skapad från grunden med `new Presentation()` rapporterar `SourceFormat.Pptx`. Den har ingen indatafil: detta är standardvärdet för en nyinstans, inte ett bevis på att en PPTX‑fil laddats. Spåra om din applikation skapade eller laddade instansen separat om den skillnaden är viktig.

## **Koppla ett källformat till en filändelse**

Följande exempel kräver `sample.pptx`. Det mappar varje för närvarande stödd [SourceFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/sourceformat/)‑värde till en konventionell filändelse, utan att analysera indatafilnamnet. Fallback‑metoden undviker att tyst tilldela en filändelse till ett okänt värde.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SourceFormat;

Presentation presentation = new Presentation("sample.pptx");
try {
    String extension;
    switch (presentation.getSourceFormat()) {
        case SourceFormat.Ppt:
            extension = ".ppt";
            break;
        case SourceFormat.Pptx:
            extension = ".pptx";
            break;
        case SourceFormat.Pptm:
            extension = ".pptm";
            break;
        case SourceFormat.Pps:
            extension = ".pps";
            break;
        case SourceFormat.Ppsx:
            extension = ".ppsx";
            break;
        case SourceFormat.Ppsm:
            extension = ".ppsm";
            break;
        case SourceFormat.Pot:
            extension = ".pot";
            break;
        case SourceFormat.Potx:
            extension = ".potx";
            break;
        case SourceFormat.Potm:
            extension = ".potm";
            break;
        case SourceFormat.Odp:
            extension = ".odp";
            break;
        case SourceFormat.Otp:
            extension = ".otp";
            break;
        case SourceFormat.Fodp:
            extension = ".fodp";
            break;
        case SourceFormat.Xml:
            extension = ".xml";
            break;
        default:
            extension = null;
            break;
    }

    System.out.println(extension != null ? extension : "No extension mapping is available.");
} finally {
    presentation.dispose();
}
```

Denna mappning konverterar inte en fil eller återställer en äldre PPS/POT‑undertyp som gått förlorad under ströminläsning. För faktisk sparning, välj ett [SaveFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/saveformat/) explicit, eller använd konverteringen som visas i [Save Presentations in Their Original Format](/slides/sv/java/save-presentation/#save-presentations-in-their-original-format).

## **Verifiera format genom att spara och öppna igen**

Detta fristående exempel skapar en presentation och skriver tre filer i arbetskatalogen, och skriver över filer med samma namn. Det öppnar varje utdata både via sökväg och genom en minnesström. För PPTX och ODP rapporterar båda vägarna det sparade formatet. För PPS rapporterar inläsning via sökväg `Pps`, medan inläsning av samma byte utan filnamn rapporterar `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.nio.file.Files;
import java.nio.file.Paths;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes = Files.readAllBytes(Paths.get(path));
            try (ByteArrayInputStream stream = new ByteArrayInputStream(bytes)) {
                Presentation fromStream = new Presentation(stream);
                try {
                    System.out.println(extensions[i] + ": file=" + fromFile.getSourceFormat() + ", stream=" + fromStream.getSourceFormat());
                } finally {
                    fromStream.dispose();
                }
            }
        } finally {
            fromFile.dispose();
        }
    }
} catch (IOException exception) {
    System.err.println("Cannot read a saved presentation: " + exception.getMessage());
} finally {
    presentation.dispose();
}
```

Följande tabell sammanfattar identifiering av källformat för presentationer med matchande filändelser. Namnen betecknar konstanter; Java‑exemplen skriver ut deras heltalsvärden:

| Sparat format | SourceFormat från en filsökväg | SourceFormat från en namnlös ström |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respektive | Samma som filsökväg |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respektive | Samma som filsökväg |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respektive | Samma som filsökväg |
| ODP, OTP | `Odp`, `Otp` respektive | Samma som filsökväg |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT-innehåll identifieras som `Ppt` för namnlösa strömmar. Tabellen beskriver formatidentifiering, inte bevarande av alla presentationsfunktioner under konvertering.

## **FAQ**

**Ändrar sparning till ODP källformatet för en presentation som laddats från PPTX?**

Nej. Den befintliga instansen rapporterar fortfarande `Pptx`. En instans som laddas från den sparade ODP‑filen rapporterar `Odp`.

**Kan en ström alltid skilja mellan en äldre presentation, ett bildspel och en mall?**

Nej. PPT, PPS och POT delar samma binära format. Behåll filnamn eller metadata för undertyp separat när den skillnaden krävs.

**Vilket API ska jag använda om presentationen redan är inläst?**

Läs [Presentation.getSourceFormat](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentation/#getSourceFormat--). Använd [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/java/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) för inspektion före inläsning.