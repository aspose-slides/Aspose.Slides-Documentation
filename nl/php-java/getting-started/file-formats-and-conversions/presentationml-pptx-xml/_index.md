---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /nl/php-java/presentationml-pptx-xml/
---
{{% alert color="primary" %}} 

PresentationML is een naam voor een familie van XML‑gebaseerde formaten voor presentatie‑documenten. Office OpenXML (OOXML) is het XML‑gebaseerde formaat dat geïntroduceerd werd in Microsoft Office 2007‑toepassingen. Office OpenXML is een containerformaat voor verschillende gespecialiseerde XML‑gebaseerde opmaak‑talen. PresentationML is de opmaak‑taal die Microsoft Office PowerPoint 2007 gebruikt om documenten op te slaan.

{{% /alert %}} 

## **PresentationML in Aspose.Slides voor PHP via Java**
OOXML PresentationML‑documenten komen als PPTX‑bestanden, zip‑XML‑pakketten die voldoen aan de [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) specificatie. Aspose.Slides voor PHP via Java ondersteunt uitgebreid het maken, lezen, manipuleren en schrijven van PresentationML‑documenten. Bovendien kan Aspose.Slides voor PHP via Java PresentationML‑documenten exporteren naar een veelgebruikt documentformaat zoals PDF. Dit is mogelijk omdat Aspose.Slides voor PHP via Java is ontworpen met als doel presentatie‑documenten grondig te verwerken, en PresentationML in feite de interne presentatie van documenten bevat als een zip‑XML‑pakket.

**Een PPTX‑document gegenereerd door Aspose.Slides voor PHP via Java en geopend in Microsoft PowerPoint**

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Hetzelfde PPTX‑document gegenereerd door Aspose.Slides voor PHP via Java bekeken in een ZIP**

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML is open, waarom Aspose.Slides voor PHP via Java gebruiken?**
Aangezien PresentationML XML‑gebaseerd is, is het goed mogelijk om applicaties te bouwen die PresentationML‑documenten verwerken en genereren met XML‑klassen zonder afhankelijk te zijn van een externe klassebibliotheek zoals Aspose.Slides voor PHP via Java. Er zijn echter verschillende voordelen aan het gebruik van Aspose.Slides voor PHP via Java ten opzichte van XML‑klassen bij het werken met PresentationML‑documenten.

De OOXML‑specificatie telt duizenden pagina’s, dus om PresentationML‑documenten correct af te handelen moet je veel tijd en moeite investeren om het formaat te begrijpen. Met Aspose.Slides voor PHP via Java gebruik je simpelweg klassen en hun methoden en eigenschappen om bewerkingen uit te voeren die complex lijken als je ze via XML‑klassen zou doen.

Enkele functies die Aspose.Slides biedt en die niet beschikbaar zijn wanneer je met PresentationML‑documenten via XML‑klassen werkt:

- Exporteren van PPT‑documenten naar PDF‑formaat.
- Een dia renderen naar elk door het Java‑framework ondersteund afbeeldingsformaat.
- Automatisch masters kopiëren van bronpresentaties met de kloon‑functie.
- Bescherming toepassen op vormen.

Hieronder staat een voorbeeld van een PresentationML‑document met één dia die een tekstvak bevat met de tekst “Hello World”. Om de tekst te lezen met XML‑klassen moet je een programma schrijven dat deze eenvoudige tekst parseert uit het volgende fragment. Aspose.Slides doet dat voor je.

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
