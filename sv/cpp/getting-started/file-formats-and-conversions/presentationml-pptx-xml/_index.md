---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /sv/cpp/presentationml-pptx-xml/
---
## **Om PresentationML**
PresentationML är ett namn för en familj av XML‑baserade format för presentationsdokument. Office OpenXML (OOXML) är det XML‑baserade format som introducerades i Microsoft Office 2007‑applikationerna. Office OpenXML är ett containerformat för flera specialiserade XML‑baserade märkspråk. PresentationML är märkspråket som används av Microsoft Office PowerPoint 2007 för att lagra sina dokument. 

## **PresentationML i Aspose.Slides för C++**
OOXML PresentationML‑dokument levereras som PPTX‑filer som är komprimerade XML‑paket enligt [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/)‑specifikationen. Aspose.Slides för C++ stöder omfattande skapande, läsning, manipulering och skrivning av PresentationML‑dokument. Dessutom kan Aspose.Slides för C++ exportera PresentationML‑dokument till olika allmänt använda dokumentformat som PDF, TIFF och XPS. Detta är möjligt eftersom Aspose.Slides för C++ designades med målet att fullt ut hantera presentationsdokument och PresentationML i princip lagrar den interna presentationen av dokument som ett komprimerat XML‑paket. 

## **PresentationML är öppen, varför använda Aspose.Slides för C++**
Eftersom PresentationML är XML‑baserat är det fullt möjligt att bygga applikationer för bearbetning och generering av PresentationML‑dokument genom att använda XML‑klasser utan att förlita sig på tredjepartsklassbibliotek som Aspose.Slides för C++. Det finns dock flera fördelar med att använda Aspose.Slides för C++ i stället för XML‑klasser när man arbetar med PresentationML‑dokument. 

OOXML‑specifikationen är mycket lång, med flera tusen sidor. Det innebär att för att på ett korrekt sätt hantera PresentationML‑dokument måste du lägga mycket tid och ansträngning på att förstå formatet för sådana dokument. Å andra sidan, när du använder Aspose.Slides för C++ behöver du bara använda de relevanta klasserna och deras respektive metoder/egenskaper för att utföra operationer som kan verka ganska komplexa om de utförs via XML‑klasser. 

Följande är några av funktionerna som till och med saknas när man hanterar PresentationML‑dokument via XML‑klasser: 

- Exportera PPT‑dokument till PDF-, TIFF‑ och XPS‑format
- Exportera bilder i PPT‑dokumenten till SVG‑format
- Rendera bild till vilket bildformat som helst som stöds av C++‑ramverket
- Automatisk kopiering av masterobjekt från källpresentationer med kloningsfunktionen
- Applicera skydd på former

Låt oss ta ett exempel på ett PresentationML‑dokument som har en enda bild med en textruta som innehåller texten “Hello World”. För att läsa texten via XML‑klasser måste du skriva ett program som kan parsra denna enkla text från följande fragment: 
## **Exempel**


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