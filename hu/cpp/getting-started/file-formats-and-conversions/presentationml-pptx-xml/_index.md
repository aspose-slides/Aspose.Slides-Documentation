---
title: PresentationML (PPTX, XML)
type: docs
weight: 20
url: /hu/cpp/presentationml-pptx-xml/
---
## **A PresentationML-ről**
A PresentationML egy név az XML-alapú formátumcsaládra, amely prezentációs dokumentumok számára készült. Az Office OpenXML (OOXML) a Microsoft Office 2007 alkalmazásokban bevezetett XML-alapú formátum. Az Office OpenXML egy konténerformátum több speciális XML-alapú jelölőnyelvhez. A PresentationML az a jelölőnyelv, amelyet a Microsoft Office PowerPoint 2007 használ a dokumentumai tárolására. 

## **PresentationML az Aspose.Slides for C++‑ban**
Az OOXML PresentationML dokumentumok PPTX fájlként érkeznek, amelyek tömörített XML csomagok a [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) specifikációknak megfelelően. Az Aspose.Slides for C++ kiterjedten támogatja a PresentationML dokumentumok létrehozását, olvasását, módosítását és írását. Emellett az Aspose.Slides for C++ képes a PresentationML dokumentumok exportálására különböző széles körben használt formátumokba, mint a PDF, TIFF és XPS. Ez azért lehetséges, mert az Aspose.Slides for C++ úgy lett tervezve, hogy teljes körűen kezelje a prezentációs dokumentumokat, és a PresentationML alapvetően a dokumentumok belső struktúráját tömörített XML csomagként tárolja. 

## **A PresentationML nyílt, miért használjuk az Aspose.Slides for C++‑t**
Mivel a PresentationML XML-alapú, könnyen lehet alkalmazásokat írni a PresentationML dokumentumok feldolgozására és létrehozására XML osztályok használatával, harmadik fél könyvtárak, például az Aspose.Slides for C++ nélkül is. Azonban több előnye is van az Aspose.Slides for C++ használatának az XML osztályokhoz képest a PresentationML dokumentumokkal való munkavégzés során. 

Az OOXML specifikáció több ezer oldalra terjed ki. Ez azt jelenti, hogy a PresentationML dokumentumok megfelelő kezelése érdekében sok időt és erőfeszítést kell fordítani a formátum megértésére. Másrészt, ha az Aspose.Slides for C++‑t használja, egyszerűen csak a megfelelő osztályokat és azok metódusait/tulajdonságait kell használnia a műveletekhez, amelyek XML osztályokkal jelentősen bonyolultabbak lennének. 

Az alábbiak olyan funkciók, amelyek XML osztályok használatával nem elérhetők a PresentationML dokumentumok kezelésében: 

- PPT dokumentumok exportálása PDF, TIFF, XPS formátumokba
- Diák exportálása a PPT dokumentumokból SVG formátumba
- Dia renderelése bármely, a C++ keretrendszer által támogatott képformátumba
- Mesterdiák automatikus másolása forrásprezentációkból a klónozási funkcióval
- Védelmi beállítások alkalmazása alakzatokra

Vegyünk egy példát egy PresentationML dokumentumra, amely egyetlen diát tartalmaz, egy szövegdobozban a „Hello World” felirattal. Ahhoz, hogy XML osztályokkal kiolvassa a szöveget, egy programot kell írni, amely képes ezt az egyszerű szöveget a következő töredékből értelmezni: 
## **Példa**


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