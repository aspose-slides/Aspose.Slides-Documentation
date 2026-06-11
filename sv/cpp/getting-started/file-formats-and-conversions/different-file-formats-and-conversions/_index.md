---
title: Olika filformat och konverteringar
type: docs
weight: 50
url: /sv/cpp/different-file-formats-and-conversions/
---
## **Microsoft PowerPoint (PPT)**
### **Om PPT**
[PPT](https://en.wikipedia.org/wiki/Microsoft_PowerPoint) är presentationsdokumentformatet som kan skapas, läsas, manipuleras och skrivas av olika versioner av Microsoft PowerPoint. Detta är det binära formatet för presentationsdokument som utvecklats av Microsoft.
### **PPT i Aspose.Slides for C++**
Aspose.Slides for C++ kan läsa PPT-filer som skapats av programvaran som listas nedan.

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003

På liknande sätt kan PPT-filer som skapats av Aspose.Slides for C++ läsas av ovanstående programvara.
### **Omfattande stöd för PPT**
Aspose.Slides for C++ erbjuder stöd för nästan alla funktioner relaterade till PPT-dokumentfilformatet. Det täcker inte bara grundläggande / avancerade funktioner som erbjuds av olika Microsoft PowerPoint-versioner för PPT-dokumentmanipulationer, utan även vissa funktioner som inte ens stöds av Microsoft PowerPoint. Den största fördelen med att använda Aspose.Slides för C++ API-biblioteket är dess användarvänlighet för hantering av sådana funktioner.

Förutom de grundläggande uppgifterna som rör att skapa, läsa och skriva PPT-dokumentfiler finns flera funktioner som tillhandahålls av Aspose.Slides för C++ såsom:
- Importera andra MS Office-filformat som OLE-objekt i PPT-dokument.
- Exportera PPT-dokument till PDF-, TIFF- och XPS-format.
- Exportera bilder i PPT-dokument till SVG-format.
- Rendera bild till vilket bildformat som helst som stöds av C++ Framework.
- Ställ in bildstorlek i PPT-dokumentet.
- Hantera animationer på former.
- Hantera bildspel.
- Formatera text på bilder.
- Skanna text från PPT-dokumenten.
- Hantera tabeller på bilder.
- Automatisk kopiering av masterbilder med kloningsfunktion.

En PPT-fil genererad av Aspose.Slides för C++ och öppnad i Microsoft PowerPoint
## **PresentationML (PPTX, XML)**
### **Om PresentationML**
PresentationML är ett namn för en familj av XML‑baserade format för presentationsdokument. Office OpenXML (OOXML) är det XML‑baserade format som introducerades i Microsoft Office 2007‑programmen. Office OpenXML är ett containerformat för flera specialiserade XML‑baserade märkspråk. PresentationML är det märkspråk som används av Microsoft Office PowerPoint 2007 för att lagra sina dokument.
### **PresentationML i Aspose.Slides for C++**
OOXML PresentationML-dokument levereras som PPTX-filer som är zipade XML‑paket i enlighet med [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/)‑specifikationerna. Aspose.Slides for C++ stöder i stor omfattning skapande, läsning, manipulering och skrivning av PresentationML-dokument. Dessutom kan Aspose.Slides for C++ exportera PresentationML-dokument till olika ofta använda dokumentformat som PDF, TIFF och XPS. Detta är möjligt eftersom Aspose.Slides for C++ är designat för att på ett omfattande sätt hantera presentationsdokument och PresentationML i princip innehåller den interna presentationen av dokument som ett zip‑XML‑paket.

En PPTX-dokument genererad av Aspose.Slides för C++ och öppnad i Microsoft PowerPoint
Visa PPTX-dokument genererad av Aspose.Slides för C++ i zip‑program
### **PresentationML är öppet, varför använda Aspose.Slides för C++**
Eftersom PresentationML är XML‑baserat är det fullt möjligt att bygga applikationer för bearbetning och generering av PresentationML‑dokument genom att använda XML‑klasser utan att förlita sig på tredjeparts‑klassbibliotek som Aspose.Slides för C++. Det finns dock flera fördelar med att använda Aspose.Slides för C++ istället för XML‑klasser när man arbetar med PresentationML‑dokument.

OOXML-specifikationen är mycket omfattande, med flera tusen sidor. Det innebär att för att korrekt hantera PresentationML‑dokument måste du lägga mycket tid och arbete på att förstå formatet för sådana dokument. Å andra sidan, när du använder Aspose.Slides för C++ behöver du bara använda de relevanta klasserna och deras respektive metoder/egenskaper för att utföra operationer som skulle vara ganska komplexa via XML‑klasser.

Nedan följer några av de funktioner som till och med saknas när man hanterar PresentationML‑dokument via XML‑klasser:
- Exportera PPT-dokument till PDF-, TIFF- och XPS-format
- Exportera bilder i PPT-dokument till SVG-format
- Rendera bild till vilket bildformat som helst som stöds av C++ Framework
- Automatisk kopiering av masterbilder från källpresentationer med kloningsfunktion
- Applicera skydd på former

Låt oss ta ett exempel på ett PresentationML‑dokument med en enda bild som innehåller en textruta med texten ”Hello World”. För att läsa texten via XML‑klasser måste du skriva ett program som kan parsra denna enkla text från följande fragment:
``` cpp

 <?xml version="1.0" encoding="UTF-8" standalone="yes"?>

<p:sld xmlns:a="http://schemas.openxmlformats.org/drawingml/2006/main" xmlns:r="http://schemas.openxmlformats.org/officeDocument/2006/relationships" xmlns:p="http://schemas.openxmlformats.org/presentationml/2006/main">

  <p:cSld>

    <p:spTree>

      <p:nvGrpSpPr>

        <p:cNvPr id="1" name=""/>

        <p:cNvGrpSpPr/>

        <p:nvPr/>

      </p:nvGrpSpPr>

      <p:grpSpPr>

        <a:xfrm>

          <a:off x="0" y="0"/>

          <a:ext cx="0" cy="0"/>

          <a:chOff x="0" y="0"/>

          <a:chExt cx="0" cy="0"/>

        </a:xfrm></p:grpSpPr><p:sp>

          <p:nvSpPr><p:cNvPr id="4" name="TextBox 3"/>

          <p:cNvSpPr txBox="1"/>

            <p:nvPr/>

          </p:nvSpPr>

          <p:spPr>

            <a:xfrm>

              <a:off x="2819400" y="2590800"/>

              <a:ext cx="1297086" cy="369332"/>

            </a:xfrm>

            <a:prstGeom prst="rect">

              <a:avLst/>

            </a:prstGeom>

            <a:noFill/>

          </p:spPr>

          <p:txBody>

            <a:bodyPr wrap="none" rtlCol="0">

              <a:spAutoFit/>

            </a:bodyPr>

            <a:lstStyle/>

            <a:p>

              <a:r>

                <a:rPr lang="en-US"/>

                <a:t>Hello World

                </a:t>

              </a:r>

              <a:endParaRPr lang="en-US"/>

            </a:p>

          </p:txBody>

        </p:sp>

    </p:spTree>

  </p:cSld>

  <p:clrMapOvr>

    <a:masterClrMapping/>

  </p:clrMapOvr>

</p:sld>

```
## **PPT till PPTX konvertering**
### **Om konvertering**
Aspose.Slides stödjer nu även konvertering från PPT till PPTX.
### **Funktioner som stöds i konvertering**
Aspose.Slides för C++ erbjuder partiellt stöd för att konvertera presentationer i PPT-dokumentfilformatet till PPTX-dokumentfilformatet. Eftersom stödet för den nämnda presentationskonverteringsfunktionen just har introducerats i Aspose.Slides för C++, har det för närvarande begränsad kapacitet och fungerar endast för enkla typer av presentationer. Den största fördelen som Aspose.Slides för C++ API‑biblioteket ger för att konvertera PPT‑presentationer till PPTX‑format är den enkla användningen av API‑et för att uppnå önskat resultat. Vänligen gå vidare till denna[link]() sektionen för kodexempel för ytterligare detaljer. Följande avsnitt illustrerar tydligt vilka funktioner som stöds och vilka som inte stöds vid konvertering av PPT‑formatpresentationer till PPTX‑formatpresentationer.
### **Stödda funktioner**
Följande funktioner stöds under konvertering:
- Konvertering av strukturen för masterbilder, layouter och bilder
- Konvertering av strukturen för masterbilder, layouter och bilder
- Konvertering av diagram
- Grupperade former
- Konvertering av autoformer inklusive rektanglar och ellipser. Det kan dock vara så att autoformer har felaktiga justeringsvärden
- Former med anpassad geometri. Kan ibland inte konverteras
- Textur- och bildfyllningsstil för autoformer. Kan ibland inte konverteras
- Konvertering av platshållare
- Konvertering av text i textramar och texthållare. Dock är punktlistor, justering och tabuleringar inte fullt implementerade
### **Ej stödda funktioner**
Följande funktioner stöds inte under konvertering:
- Slide med anteckningar eftersom läsning av anteckningar inte är implementerat i PPTX. Om PPT har det kan den ännu inte sparas som PPTX.
- Konvertering av linjer och polylinjer
- Linje- och fyllningsformat
- Gradientfyllningsstilar
- OLE‑ramar, tabeller, video‑ och ljudramar osv
- Animation och andra bildspelsegenskaper hoppas över
Nya eller saknade funktioner kommer att läggas till i kommande utgåvor av Aspose.Slides för C++.

Käll‑PPT‑presentation

Konverterad PPTX‑presentation
## **Portable Document Format (PDF)**
### **Om PDF**
[Portable Document Format](https://en.wikipedia.org/wiki/PDF) är ett filformat som skapades av Adobe Systems för utbyte av dokument mellan olika organisationer. Syftet med detta format är att möjliggöra att dokumentens innehåll kan representeras på ett sätt så att deras visuella utseende inte är beroende av den plattform på vilken de visas.
### **PDF i Aspose.Slides for C++**
Alla presentationsdokument som kan laddas in i Aspose.Slides för C++ kan konverteras till PDF-dokument som kan följa [PDF 1.5](https://en.wikipedia.org/wiki/PDF/A) eller [PDF /A‑1b](https://en.wikipedia.org/wiki/PDF/A) beroende på ditt val. Aspose.Slides för C++ exporterar presentationsdokument till PDF på ett sätt så att det exporterade PDF-dokumentet oftast ser nästan identiskt ut som det ursprungliga presentationsdokumentet. Aspose‑lösningen stödjer följande funktioner i presentationsdokument vid konvertering till PDF-dokument:
- Bilder, textrutor och andra former
- Text och formatering
- Paragrafer och formatering
- Hyperlänkar
- Sidhuvuden och sidfötter
- Punktlistor
- Tabeller

Du kan exportera presentationsdokument till PDF-dokument direkt med bara Aspose.Slides för C++-komponenten. Det innebär att du inte behöver någon annan tredjeparts- eller Aspose.Pdf-komponent för detta ändamål. Dessutom kan du anpassa exporten från presentation till PDF med olika alternativ som förklaras i [denna artikel](/slides/sv/cpp/convert-powerpoint-to-pdf/).

Ett presentationsdokument konverterat till PDF-dokument via Aspose.Slides för C++
## **XML Parser Specification (XPS)**
### **Om XPS**
[XML Parser Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) är ett sidbeskrivningsspråk och ett fast dokumentformat som ursprungligen utvecklades av Microsoft. Likt PDF är XPS ett fast layout‑dokumentformat designat för att bevara dokumentets trohet och ge en enhetsoberoende dokumentpresentation.
### **XPS i Aspose.Slides for C++**
Alla presentationsdokument som kan laddas av Aspose.Slides för C++ kan konverteras till XPS-format. Aspose.Slides för C++ använder den högupplösta sidlayout- och renderingsmotorn för att producera utdata i fast‑layout XPS-dokumentformat. Det är värt att nämna att Aspose.Slides för C++ genererar XPS direkt utan att förlita sig på Windows Presentation Foundation (WPF)-klasser som paketeras med C++ Framework 3.5, vilket gör att Aspose.Slides för C++ kan producera XPS-dokument på maskiner som kör C++ Framework‑versioner tidigare än 3.5. Du kan läsa om export av presentationsdokument till XPS-dokument via Aspose.Slides för C++ i [denna artikel](https://docs.aspose.com/slides/sv/cpp/convert-powerpoint-to-xps/).

Ett presentationsdokument konverterat till XPS-dokument via Aspose.Slides för C++