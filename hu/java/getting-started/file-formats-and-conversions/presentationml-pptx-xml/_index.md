---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /hu/java/presentationml-pptx-xml/
---
{{% alert color="info" %}} 
PresentationML egy név egy XML-alapú formátumcsaládra, amely prezentációs dokumentumokat takar. Az Office OpenXML (OOXML) a Microsoft Office 2007 alkalmazásokban bevezetett XML-alapú formátum. Az Office OpenXML egy konténerformátum több speciális XML-alapú jelölőnyelvhez. A PresentationML a Microsoft Office PowerPoint 2007 által a dokumentumok tárolására használt jelölőnyelv.
{{% /alert %}} 

## **PresentationML az Aspose.Slides for Java‑ban**
Az OOXML PresentationML dokumentumok PPTX fájlokként érkeznek, tömörített XML csomagok, amelyek megfelelnek a [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) specifikációnak. Az Aspose.Slides for Java kiterjedten támogatja a PresentationML dokumentumok létrehozását, olvasását, módosítását és írását. Emellett az Aspose.Slides for Java képes a PresentationML dokumentumok exportálására egy széles körben használt dokumentumformátumba, például PDF-be. Ez lehetséges, mert az Aspose.Slides for Java úgy lett tervezve, hogy átfogóan kezelje a prezentációs dokumentumokat, és a PresentationML lényegében egy tömörített XML csomagként tartalmazza a dokumentumok belső ábrázolását.

**Az Aspose.Slides for Java által generált PPTX dokumentum, amelyet a Microsoft PowerPoint nyit meg** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Az ugyanazon, az Aspose.Slides for Java által generált PPTX dokumentum ZIP-ben történő megtekintése** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **A PresentationML nyílt, miért használja az Aspose.Slides for Java‑t?**
Mivel a PresentationML XML-alapú, teljesen lehetséges alkalmazásokat építeni a PresentationML dokumentumok feldolgozására és előállítására XML osztályok segítségével, anélkül, hogy harmadik féltől származó osztálykönyvtárra, például az Aspose.Slides for Java-ra támaszkodnánk. Ennek ellenére több előnye is van az Aspose.Slides for Java használatának XML osztályokkal szemben a PresentationML dokumentumok kezelésekor.

Az OOXML specifikáció több ezer oldalon terjed, így a PresentationML dokumentumok megfelelő kezelése érdekében sok időt és erőfeszítést kell fordítani a formátum megismerésére. Másrészt az Aspose.Slides for Java esetében egyszerűen osztályokat, valamint azok metódusait és tulajdonságait használva végezhet el olyan műveleteket, amelyek XML osztályokkal való megvalósítás esetén bonyolultnak tűnnek.

Néhány, az Aspose.Slides által kínált funkció egyáltalán nem érhető el, ha PresentationML dokumentumokkal XML osztályok segítségével dolgozik:

- PPT dokumentumok exportálása PDF formátumba.
- Diák renderelése bármely, a Java keretrendszer által támogatott képformátumba.
- Mesterek automatikus másolása forrásprezentációkból a klónozási funkció használatával.
- Védelem alkalmazása alakzatokra.

Alább egy példa egy PresentationML dokumentumra, amely egyetlen diát tartalmaz, azon egy szövegdoboz a “Hello World” szöveggel. A szöveg XML osztályokkal történő kiolvasásához egy olyan programot kell írnia, amely képes feldolgozni ezt az egyszerű szöveget az alábbi töredékből. Az Aspose.Slides ezt megteszi az Ön helyett.

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