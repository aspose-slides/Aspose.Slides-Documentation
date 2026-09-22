---
title: "Bestäm det ursprungliga presentationsformatet på Android"
linktitle: "Källformat"
type: docs
weight: 35
url: /sv/androidjava/detect-presentation-source-format/
keywords:
- "källformat"
- "detektera presentationsformat"
- "PowerPoint"
- "OpenDocument"
- "presentation"
- "PPT"
- "PPTX"
- "Android"
- "Java"
- "Aspose.Slides"
description: "Läs det ursprungliga formatet för en inläst presentation på Android med Aspose.Slides för Android via Java, jämför identifierings‑API:er och hantera filer, strömmar och äldre format."
---
## **Översikt**

Efter att en presentation har lästs in, anropa metoden [Presentation.getSourceFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getSourceFormat--) för att fastställa dess ursprungliga format. Metoden är också tillgänglig via [IPresentation.getSourceFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentation/#getSourceFormat--). Använd den när efterföljande bearbetning beror på det format som den aktuella instansen laddades från.

Källformatet är skilt från det [SaveFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/saveformat/) som väljs för en utdatafil. Att spara till ett annat format ändrar inte källformatet för den befintliga instansen.

Exemplen använder Java och filsökvägar. På Android ska du ersätta exempelvägarna med sökvägar i appens åtkomliga lagring, till exempel appens interna katalog för filer.

## **Läs källformatet för en fil**

Detta exempel kräver en befintlig `sample.pptx`‑fil. Det läser in filen och väljer en bearbetningspolicy för applikationen med hjälp av [Presentation.getSourceFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getSourceFormat--), snarare än filnamnet. Ändra indatasökvägen för att prova andra format. Exemplet skriver ut den valda policyn; ersätt meddelandena med din applikationslogik.

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

## **Känna igen de stödjade värdena**

[SourceFormat]-klassen definierar heltalskonstanter som skiljer mellan följande presentationsformat. Filändelserna nedan är konventionella ändelser, inte en återuppbyggnad av det ursprungliga filnamnet.

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
| `Otp` | `.otp` | OpenDocument‑presentationsmall |
| `Fodp` | `.fodp` | Flat XML ODF‑presentation |
| `Xml` | `.xml` | PowerPoint XML‑presentation |

## **Läs källformatet för en ström**

Detta exempel kräver en befintlig `sample.pps`‑fil. Att läsa dess byte till en minnesström efterliknar indata som mottas utan ett filnamn, t.ex. ett databasinnehåll eller en uppladdad byte‑array. [Presentation]-konstruktorn tar bara emot strömmen.

```java
import com.aspose.slides.Presentation;
import java.io.ByteArrayInputStream;
import java.io.IOException;
import java.io.ByteArrayOutputStream;
import java.io.FileInputStream;

try {
    byte[] bytes;
    try (FileInputStream input = new FileInputStream("sample.pps");
         ByteArrayOutputStream output = new ByteArrayOutputStream()) {
        byte[] buffer = new byte[8192];
        int bytesRead;
        while ((bytesRead = input.read(buffer)) != -1) {
            output.write(buffer, 0, bytesRead);
        }
        bytes = output.toByteArray();
    }
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

PPT, PPS och POT använder samma underliggande binära format. Vid inläsning via filsökväg kan filändelsen hjälpa till att skilja ett bildspel eller en mall. Utan ett filnamn kan äldre PPS‑ och POT‑innehåll rapporteras som `SourceFormat.Ppt`; PPS‑exemplet ovan skriver ut heltalsvärdet för `SourceFormat.Ppt`.

Om din applikation måste bevara skillnaden, behåll det ursprungliga filnamnet eller metadata för undertypen separat. En filändelse är en användbar ledtråd för dessa äldre subtyper, men bör inte vara den enda grunden för att identifiera godtyckligt presentationsinnehåll.

## **Jämför identifiering före och efter inläsning**

Använd [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) och [IPresentationInfo.getLoadFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/ipresentationinfo/#getLoadFormat--) när du behöver inspektera en fil innan hela presentationsobjektmodellen laddas. Använd [Presentation.getSourceFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getSourceFormat--) när instansen redan finns.

Detta exempel kräver `sample.pptx` och skriver ut heltalsvärdena för `LoadFormat.Pptx` respektive `SourceFormat.Pptx`. I produktion bör du välja det API som passar ditt bearbetningssteg; en redan inläst presentation behöver inte en andra inspektion enbart för att hämta dess källformat.

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

Resultaten använder konstanter från olika klasser: [LoadFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/loadformat/) och [SourceFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/sourceformat/). Jämför inte deras numeriska värden eller anta att varje format har identiska identifieringsresultat. PowerPoint XML kan rapporteras som `LoadFormat.Unknown` före inläsning och `SourceFormat.Xml` efter inläsning.

## **Behåll käll- och utdataformat separata**

Detta exempel kräver `sample.pptx` och skriver `converted.odp`. Det skriver ut heltalsvärdet för `SourceFormat.Pptx` både före och efter att den ursprungliga instansen sparats. Endast den nya instansen som laddas från ODP‑utdata rapporterar `Odp`.

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

En presentation som skapas från början med `new Presentation()` rapporterar `SourceFormat.Pptx`. Den har ingen indatafil: detta är standardvärdet för en nyinstans, inte ett bevis på att en PPTX‑fil har lästs in. Följ om din applikation skapade eller läste in instansen separat om den skillnaden är viktig.

## **Mappa ett källformat till en filändelse**

Följande exempel kräver `sample.pptx`. Det mappar varje för närvarande stödjat [SourceFormat]-värde till en konventionell filändelse, utan att analysera indatafilnamnet. Fallback‑mekanismen undviker att tyst tilldela en filändelse till ett okänt värde.

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

Denna mappning konverterar inte en fil eller återställer en äldre PPS/POT‑subtyp som går förlorad vid strömlinläsning. För faktisk sparning, välj ett [SaveFormat] explicit, eller använd konverteringen som visas i [Save Presentations in Their Original Format](/slides/sv/androidjava/save-presentation/#save-presentations-in-their-original-format).

## **Verifiera format genom att spara och öppna igen**

Detta fristående exempel skapar en presentation och skriver tre filer i arbetskatalogen, och skriver över filer med samma namn. Det öppnar varje utdata både via sökväg och genom en minnesström. För PPTX och ODP rapporterar båda vägarna det sparade formatet. För PPS rapporterar inläsning via sökväg `Pps`, medan inläsning av samma byte utan ett filnamn rapporterar `Ppt`.

```java
import com.aspose.slides.Presentation;
import com.aspose.slides.SaveFormat;
import java.io ByteArrayInputStream;
import java.io.IOException;
import java.io ByteArrayOutputStream;
import java.io FileInputStream;

Presentation presentation = new Presentation();
try {
    int[] formats = { SaveFormat.Pptx, SaveFormat.Odp, SaveFormat.Pps };
    String[] extensions = { "pptx", "odp", "pps" };

    for (int i = 0; i < formats.length; i++) {
        String path = "roundtrip." + extensions[i];
        presentation.save(path, formats[i]);

        Presentation fromFile = new Presentation(path);
        try {
            byte[] bytes;
            try (FileInputStream input = new FileInputStream(path);
                 ByteArrayOutputStream output = new ByteArrayOutputStream()) {
                byte[] buffer = new byte[8192];
                int bytesRead;
                while ((bytesRead = input.read(buffer)) != -1) {
                    output.write(buffer, 0, bytesRead);
                }
                bytes = output.toByteArray();
            }
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

Följande tabell sammanfattar källformatidentifiering för presentationer med matchande filändelser. Namnen betecknar konstanter; Java‑exemplen skriver ut deras heltalsvärden:

| Sparat format | SourceFormat från en filsökväg | SourceFormat från en namnlös ström |
| --- | --- | --- |
| PPT | `Ppt` | `Ppt` |
| PPTX, PPTM | `Pptx`, `Pptm` respectively | Same as file path |
| PPS | `Pps` | `Ppt` |
| PPSX, PPSM | `Ppsx`, `Ppsm` respectively | Same as file path |
| POT | `Pot` | `Ppt` |
| POTX, POTM | `Potx`, `Potm` respectively | Same as file path |
| ODP, OTP | `Odp`, `Otp` respectively | Same as file path |
| FODP | `Fodp` | `Fodp` |
| PowerPoint XML | `Xml` | `Xml` |

PPS/POT‑innehåll identifieras som `Ppt` för namnlösa strömmar. Tabellen beskriver formatidentifiering, inte bevarande av varje presentationsfunktion under konvertering.

## **Vanliga frågor**

**Ändrar sparning till ODP källformatet för en presentation som laddats från PPTX?**

Nej. Den befintliga instansen rapporterar fortfarande `Pptx`. En instans som laddas från den sparade ODP‑filen rapporterar `Odp`.

**Kan en ström alltid särskilja en äldre presentation, ett bildspel och en mall?**

Nej. PPT, PPS och POT delar det binära formatet. Behåll filnamnet eller metadata för undertypen separat när den skillnaden krävs.

**Vilket API ska jag använda om presentationen redan är inläst?**

Läs [Presentation.getSourceFormat](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentation/#getSourceFormat--). Använd [PresentationFactory.getPresentationInfo](https://reference.aspose.com/slides/sv/androidjava/com.aspose.slides/presentationfactory/#getPresentationInfo-java.lang.String-) för inspektion före inläsning.