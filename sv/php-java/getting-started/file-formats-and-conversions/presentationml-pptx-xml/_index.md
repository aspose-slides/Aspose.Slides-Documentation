---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /sv/php-java/presentationml-pptx-xml/
---
{{% alert color="primary" %}} 

PresentationML är ett namn för en familj av XML‑baserade format för presentationsdokument. Office OpenXML (OOXML) är det XML‑baserade format som introducerades i Microsoft Office 2007‑programmen. Office OpenXML är ett containerformat för flera specialiserade XML‑baserade märkningsspråk. PresentationML är märkspråket som Microsoft Office PowerPoint 2007 använder för att lagra dokument.

{{% /alert %}} 

## **PresentationML i Aspose.Slides för PHP via Java**
OOXML PresentationML‑dokument levereras som PPTX‑filer, zip‑ade XML‑paket som följer [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/)‑specifikationen. Aspose.Slides för PHP via Java stöder omfattande skapande, läsning, manipulation och skrivning av PresentationML‑dokument. Dessutom kan Aspose.Slides för PHP via Java exportera PresentationML‑dokument till ett allmänt använt dokumentformat som PDF. Detta är möjligt eftersom Aspose.Slides för PHP via Java designades med syftet att helt hantera presentationsdokument och PresentationML i grund och botten lagrar den interna presentationen av dokument som ett zip‑at XML‑paket.

**Ett PPTX‑dokument genererat av Aspose.Slides för PHP via Java och öppnat i Microsoft PowerPoint**

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Visning av samma PPTX‑dokument genererat av Aspose.Slides för PHP via Java i en ZIP**

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML är öppen, varför använda Aspose.Slides för PHP via Java?**
Eftersom PresentationML är XML‑baserat är det fullt möjligt att bygga applikationer som behandlar och genererar PresentationML‑dokument med XML‑klasser utan att förlita sig på ett tredjepartsbibliotek som Aspose.Slides för PHP via Java. Det finns dock flera fördelar med att använda Aspose.Slides för PHP via Java jämfört med XML‑klasser när man arbetar med PresentationML‑dokument.

OOXML‑specifikationen är flera tusen sidor lång, så för att korrekt hantera PresentationML‑dokument måste du lägga mycket tid och ansträngning på att förstå formatet. Å andra sidan, med Aspose.Slides för PHP via Java, använder du helt enkelt klasser och deras metoder och egenskaper för att utföra operationer som kan verka komplexa om de utförs via XML‑klasser.

Vissa av funktionerna som Aspose.Slides erbjuder är inte ens tillgängliga när du arbetar med PresentationML‑dokument via XML‑klasser:

- Exportera PPT‑dokument till PDF‑format.
- Rendera en bild till något bildformat som stöds av Java‑ramverket.
- Kopiera automatiskt masterbilder från en källpresentation med kloningsfunktionen.
- Tillämpa skydd på former.

Nedan är ett exempel på ett PresentationML‑dokument med en enda bild som innehåller en textruta med texten “Hello World”. För att läsa texten med XML‑klasser måste du skriva ett program som kan parsra denna enkla text från följande fragment. Aspose.Slides gör detta åt dig.

**XML**

``` xml
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
```php
