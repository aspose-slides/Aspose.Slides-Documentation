---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /hu/java/presentationml-pptx-xml/
---
{{% alert color="primary" %}} 

A PresentationML egy név a prezentációs dokumentumok XML-alapú formátumcsaládjára. Az Office OpenXML (OOXML) a Microsoft Office 2007 alkalmazásokban bevezetett XML-alapú formátum. Az Office OpenXML egy konténerformátum több speciális XML-alapú jelölőnyelvhez. A PresentationML az a jelölőnyelv, amelyet a Microsoft Office PowerPoint 2007 a dokumentumok tárolására használ.

{{% /alert %}} 

## **PresentationML az Aspose.Slides for Java-ban**
Az OOXML PresentationML dokumentumok PPTX fájlokként jelennek meg, tömörített XML csomagokként, amelyek az [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) specifikációt követik. Az Aspose.Slides for Java kiterjedten támogatja a PresentationML dokumentumok létrehozását, olvasását, módosítását és írását. Emellett az Aspose.Slides for Java képes a PresentationML dokumentumokat széles körben használt formátumba, például PDF‑be exportálni. Ez azért lehetséges, mert az Aspose.Slides for Java-t úgy tervezték, hogy átfogóan kezelje a prezentációs dokumentumokat, és a PresentationML lényegében egy tömörített XML csomagban tárolja a dokumentumok belső szerkezetét.

**Egy PPTX dokumentum, amelyet az Aspose.Slides for Java generált, és a Microsoft PowerPointben megnyitott** 

![todo:image_alt_text](presentationml-pptx-xml_1.png)


**Az ugyanazon Aspose.Slides for Java által generált PPTX dokumentum megtekintése ZIP‑ben** 

![todo:image_alt_text](presentationml-pptx-xml_2.jpg)


## **PresentationML nyílt, miért használjuk az Aspose.Slides for Java‑t?**
Mivel a PresentationML XML‑alapú, lehetséges olyan alkalmazásokat építeni, amelyek PresentationML dokumentumokat dolgoznak fel és generálnak XML osztályokkal, anélkül, hogy harmadik fél könyvtárára, például az Aspose.Slides for Java‑ra támaszkodnának. Ugyanakkor több előnye is van az Aspose.Slides for Java használatának az XML osztályokhoz képest a PresentationML dokumentumok kezelésekor.

Az OOXML specifikáció több ezer oldalon terjed, ezért a PresentationML dokumentumok megfelelő kezelése jelentős időt és erőfeszítést igényel a formátum megértéséhez. Ezzel szemben az Aspose.Slides for Java esetén csak osztályokat, azok metódusait és tulajdonságait használja, hogy olyan műveleteket hajtson végre, amelyek XML osztályokkal bonyolultabbak lennének.

Néhány funkció, amelyet az Aspose.Slides kínál, XML osztályokkal a PresentationML dokumentumok kezelése során nem érhető el:

- PPT dokumentumok exportálása PDF formátumba.
- Dia renderelése a Java keretrendszer által támogatott bármely képformátumba.
- Mester diák automatikus másolása forrásprezentációkból a klónozási funkcióval.
- Védelem alkalmazása alakzatokra.

Az alábbiakban egy PresentationML dokumentum látható, amely egyetlen diát tartalmaz, azon egy szövegdobozban a “Hello World” felirat. A szöveg XML osztályokkal történő kiolvasásához egy programot kell írni, amely képes ezt az egyszerű szöveget a következő részletből kinyerni. Az Aspose.Slides ezt Ön helyett megteszi.

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