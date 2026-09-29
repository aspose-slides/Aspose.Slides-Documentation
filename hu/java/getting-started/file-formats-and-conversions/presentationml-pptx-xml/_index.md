---
title: PresentationML (PPTX, XML) (Történeti)
type: docs
weight: 20
url: /hu/java/presentationml-pptx-xml/
keywords:
- PresentationML
- PPTX
- Office Open XML
- történeti
- Java
- Aspose.Slides
description: "Történeti: egy régebbi áttekintés a PresentationML (PPTX) formátumról az Aspose.Slides for Java-ban, a meglévő hivatkozások miatt megőrizve. A támogatott formátumok aktuális listája a Supported File Formats oldalon."
---
{{% alert color="info" title="Note" %}}
Ez egy történeti oldal, amely a meglévő hivatkozások miatt megmaradt. Nem írja le az Aspose.Slides for Java jelenlegi verzióját. Az Aspose.Slides for Java által betöltött, importált, mentett és megjelenített formátumok, valamint azok API-ja megtalálható a [Supported File Formats](/slides/hu/java/supported-file-formats/) oldalon. A PPTX és a PPT összehasonlításához lásd a [Understanding the Difference: PPT vs PPTX](/slides/hu/java/ppt-vs-pptx/) oldalt.
{{% /alert %}}
{{% alert color="info" title="Note" %}}
A PresentationML egy név a prezentációs dokumentumok XML-alapú formátumcsaládjára. Az Office OpenXML (OOXML) a Microsoft Office 2007 alkalmazásokban bevezetett XML-alapú formátum. Az Office OpenXML egy tárolóformátum több specializált XML-alapú leírónyelvhez. A PresentationML az a leírónyelv, amelyet a Microsoft Office PowerPoint 2007 használ a dokumentumok tárolására.
{{% /alert %}}
## **PresentationML az Aspose.Slides for Java-ban**
Az OOXML PresentationML dokumentumok PPTX fájlként érkeznek, tömörített XML csomagokként, amelyek követik a [OOXML ECMA-376](https://ecma-international.org/publications-and-standards/standards/ecma-376/) specifikációt. Az Aspose.Slides for Java kiterjedten támogatja a PresentationML dokumentumok létrehozását, olvasását, manipulálását és írását. Ezen felül az Aspose.Slides for Java képes a PresentationML dokumentumokat széles körben használt dokumentumformátumba, például PDF-be exportálni. Ez lehetséges, mert az Aspose.Slides for Java úgy lett tervezve, hogy átfogóan kezelje a prezentációs dokumentumokat, és a PresentationML alapvetően a dokumentumok belső strukturáját egy tömörített XML csomagként tárolja.
**Az Aspose.Slides for Java által generált PPTX dokumentum, amely Microsoft PowerPointban nyílik meg**
![Az Aspose.Slides for Java által generált PPTX dokumentum, amely Microsoft PowerPointban nyílik meg](presentationml-pptx-xml_1.png)

**Az ugyanazon, Aspose.Slides for Java által generált PPTX dokumentum megtekintése ZIP formátumban**
![Azonos PPTX dokumentum ZIP csomagként megtekintve](presentationml-pptx-xml_2.jpg)

## **A PresentationML nyílt, miért használjuk az Aspose.Slides for Java-t?**
Mivel a PresentationML XML-alapú, teljesen lehetséges olyan alkalmazásokat építeni, amelyek XML osztályokkal dolgozzák fel és generálják a PresentationML dokumentumokat anélkül, hogy harmadik féltől származó osztálykönyvtárra, például az Aspose.Slides for Java-ra támaszkodnának. Mindazonáltal számos előnye van az Aspose.Slides for Java használatának az XML osztályokkal szemben a PresentationML dokumentumokkal való munka során.
Az OOXML specifikáció több ezer oldalból áll, ezért a PresentationML dokumentumok megfelelő kezelése érdekében sok időt és erőfeszítést kell szánni a formátum megértésére. Ezzel szemben az Aspose.Slides for Java esetében egyszerűen osztályokat, metódusokat és tulajdonságokat használunk a műveletek elvégzéséhez, amelyek XML osztályokkal való megvalósítás esetén összetettnek tűnnek.
Néhány, az Aspose.Slides által kínált funkció még akkor sem érhető el, ha XML osztályokkal dolgozol a PresentationML dokumentumokon:
- PPT dokumentumok exportálása PDF formátumba.
- Dia renderelése bármely, a Java keretrendszer által támogatott képf formátumba.
- Mesterek automatikus másolása egy forrásprezentációból a klónozási funkció használatával.
- Alakzatokra védelem alkalmazása.
Az alábbiakban egy PresentationML dokumentum példát láthatunk, amely egyetlen diát tartalmaz, benne egy szövegdoboz a “Hello World” szöveggel. A szöveg XML osztályokkal történő kiolvasásához egy olyan programot kell írni, amely képes feldolgozni ezt az egyszerű szöveget az alábbi töredékből. Az Aspose.Slides ezt helyetted elvégzi.
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
```