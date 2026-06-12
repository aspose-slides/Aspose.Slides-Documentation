---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /nl/cpp/presentationml-pptx-xml/
---
## **Over PresentationML**
PresentationML is een benaming voor een familie van XML‑gebaseerde formaten voor presentatiedocumenten. Office OpenXML (OOXML) is het XML‑gebaseerde formaat dat is geïntroduceerd in Microsoft Office 2007‑toepassingen. Office OpenXML is een containerformaat voor verschillende gespecialiseerde XML‑gebaseerde opmaak‑talen. PresentationML is de opmaak‑taal die door Microsoft Office PowerPoint 2007 wordt gebruikt om zijn documenten op te slaan.

## **PresentationML in Aspose.Slides voor C++**
OOXML PresentationML‑documenten worden geleverd als PPTX‑bestanden die zip‑XML‑pakketten zijn volgens de [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) specificaties. Aspose.Slides voor C++ ondersteunt uitgebreid het maken, lezen, manipuleren en schrijven van PresentationML‑documenten. Bovendien kan Aspose.Slides voor C++ PresentationML‑documenten exporteren naar verschillende veelgebruikte documentformaten zoals PDF, TIFF en XPS. Dit is mogelijk omdat Aspose.Slides voor C++ is ontworpen met als doel presentatiedocumenten volledig te verwerken en PresentationML in feite de interne presentatie van documenten bevat als een zip‑XML‑pakket.

## **PresentationML is Open, waarom Aspose.Slides voor C++ gebruiken**
Aangezien PresentationML XML‑gebaseerd is, is het goed mogelijk om toepassingen te bouwen voor het verwerken en genereren van PresentationML‑documenten met behulp van XML‑klassen zonder afhankelijk te zijn van externe bibliotheken zoals Aspose.Slides voor C++. Er zijn echter verschillende voordelen om Aspose.Slides voor C++ te gebruiken ten opzichte van XML‑klassen bij het werken met PresentationML‑documenten.

De OOXML‑specificatie is zeer omvangrijk, met enkele duizenden pagina's. Dat betekent dat je, om PresentationML‑documenten correct te kunnen verwerken, veel tijd en moeite moet besteden aan het begrijpen van het formaat van dergelijke documenten. Aan de andere kant, met Aspose.Slides voor C++ hoef je alleen de relevante klassen en hun respectieve methoden/eigenschappen te gebruiken voor het uitvoeren van handelingen die nogal complex lijken wanneer ze via XML‑klassen worden gedaan.

De volgende zijn enkele functies die zelfs niet beschikbaar zijn bij het behandelen van PresentationML‑documenten via XML‑klassen:
- PPT‑documenten exporteren naar PDF-, TIFF- en XPS‑formaten
- Dia's in de PPT‑documenten exporteren naar SVG‑formaten
- Dia renderen naar elk afbeeldingsformaat dat door het C++‑framework wordt ondersteund
- Automatisch kopiëren van masters uit bronpresentaties met de kloon‑functie
- Bescherming toepassen op vormen

Laten we een voorbeeld nemen van een PresentationML‑document met één dia met één tekstvak dat de tekst “Hello World” bevat. Om de tekst via XML‑klassen uit te lezen, moet je een programma schrijven dat deze eenvoudige tekst kan parseren uit het volgende fragment:

## **Voorbeeld**

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