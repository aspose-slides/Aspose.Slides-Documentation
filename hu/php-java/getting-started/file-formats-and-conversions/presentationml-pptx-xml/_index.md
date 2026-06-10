---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /hu/php-java/presentationml-pptx-xml/
---
{{% alert color="primary" %}} 
A PresentationML egy név egy XML-alapú formátumcsaládra, amely prezentációs dokumentumok számára készült. Az Office OpenXML (OOXML) egy XML-alapú formátum, amelyet a Microsoft Office 2007 alkalmazások vezettek be. Az Office OpenXML egy konténerformátum több speciális XML-alapú jelölőnyelvhez. A PresentationML a Microsoft Office PowerPoint 2007 által a dokumentumok tárolására használt jelölőnyelv.
{{% /alert %}} 

## **PresentationML az Aspose.Slides for PHP via Java-ban**
Az OOXML PresentationML dokumentumok PPTX fájlokként érkeznek, tömörített XML csomagokként, amelyek megfelelnek az [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) specifikációnak. Az Aspose.Slides for PHP via Java kiterjedten támogatja a PresentationML dokumentumok létrehozását, olvasását, módosítását és írását. Ezen felül az Aspose.Slides for PHP via Java képes a PresentationML dokumentumok exportálására széles körben használt dokumentumformátumba, például PDF-be. Ez lehetséges, mert az Aspose.Slides for PHP via Java úgy lett tervezve, hogy átfogóan kezelje a prezentációs dokumentumokat, és a PresentationML alapvetően egy tömörített XML csomagként tárolja a dokumentumok belső szerkezetét.

**Az Aspose.Slides for PHP via Java által generált PPTX dokumentum, amelyet a Microsoft PowerPoint nyit meg**

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Az ugyanazon, Aspose.Slides for PHP via Java által generált PPTX dokumentum ZIP-ben való megtekintése**

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML nyílt, miért használja az Aspose.Slides for PHP via Java?**
Mivel a PresentationML XML-alapú, teljesen lehetséges olyan alkalmazásokat építeni, amelyek a PresentationML dokumentumokat XML osztályokkal dolgozzák fel és generálják, anélkül, hogy harmadik féltől származó osztálykönyvtárra, például az Aspose.Slides for PHP via Java-ra támaszkodnának. Ugyanakkor számos előnyt kínál az Aspose.Slides for PHP via Java használata XML osztályokkal szemben a PresentationML dokumentumokkal való munka során.

Az OOXML specifikáció több ezer oldal hosszú, ezért a PresentationML dokumentumok megfelelő kezelése érdekében sok időt és erőfeszítést kell a formátum megértésébe fektetni. Másrészt, az Aspose.Slides for PHP via Java esetén csak osztályokat, azok metódusait és tulajdonságait használja olyan műveletek végrehajtásához, amelyek XML osztályokkal végezve bonyolultnak tűnnek.

Néhány olyan funkció, amelyet az Aspose.Slides kínál, még az XML osztályokkal dolgozva sem elérhető a PresentationML dokumentumok kezelésénél:
- PPT dokumentumok exportálása PDF formátumba.
- Dia renderelése bármely, a Java keretrendszer által támogatott képtípusra.
- Mesterek automatikus másolása forrásprezentációkból a klónozási funkció segítségével.
- Védelmi beállítások alkalmazása alakzatokra.

Az alábbiakban egy példa látható egy PresentationML dokumentumra, amely egyetlen diát tartalmaz, azon egy szövegdobozban a “Hello World” szöveggel. A szöveg XML osztályokkal való beolvasásához egy programot kell írni, amely képes ezt az egyszerű szöveget a következő részletből kiolvasni. Az Aspose.Slides ezt megteszi Ön helyett.

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
