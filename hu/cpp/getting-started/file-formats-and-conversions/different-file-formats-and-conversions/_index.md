---
title: Különböző fájlformátumok és konverziók
type: docs
weight: 50
url: /hu/cpp/different-file-formats-and-conversions/
---
## **Microsoft PowerPoint (PPT)**
### **A PPT-ről**
[PPT](https://en.wikipedia.org/wiki/Microsoft_PowerPoint) a prezentációs dokumentum fájlformátum, amelyet a különböző Microsoft PowerPoint verziók képesek létrehozni, olvasni, manipulálni és írni. Ez a Microsoft által fejlesztett prezentációs dokumentumok bináris formátuma.
### **A PPT az Aspose.Slides for C++-ban**
Aspose.Slides for C++ képes olvasni a lent felsorolt szoftverek által létrehozott PPT-fájlokat.

- Microsoft PowerPoint 97
- Microsoft PowerPoint 2000
- Microsoft PowerPoint XP
- Microsoft PowerPoint 2003

Ugyanígy az Aspose.Slides for C++ által létrehozott PPT-fájlok is olvashatók a fenti szoftverekkel.
### **Átfogó támogatás a PPT-hez**
Aspose.Slides for C++ szinte minden, a PPT-dokumentum fájlformátummal kapcsolatos funkciót támogat. Nem csak a különböző Microsoft PowerPoint verziók által biztosított alapvető / haladó funkciókat fedi le a PPT-dokumentumok manipulálásához, hanem olyan funkciókat is, melyeket a Microsoft PowerPoint még nem támogat. Az Aspose.Slides for C++ API könyvtár használatának fő előnye a könnyű használhatóság az ilyen funkciók kezelésében.

Az alapvető PPT-dokumentumok létrehozásával, olvasásával és írásával kapcsolatos feladatokon túl az Aspose.Slides for C++ több funkciót is biztosít, például:

- Más MS Office fájlformátumok importálása OLE objektumként a PPT-dokumentumokba.
- PPT-dokumentumok exportálása PDF, TIFF, XPS formátumokba.
- Dia exportálása a PPT-dokumentumokban SVG formátumba.
- Dia renderelése a C++ Framework által támogatott bármely képfformátumba.
- Dia méretének beállítása a PPT-dokumentumban.
- Animációk kezelése az alakzatokon.
- Diavetítések kezelése.
- Szöveg formázása a diákon.
- Szöveg beolvasása a PPT-dokumentumokból.
- Táblák kezelése a diákon.
- Mesterek automatikus másolása klónozási funkcióval.

Egy PPT-fájl, amelyet az Aspose.Slides for C++ generált, és a Microsoft PowerPoint-ben megnyitott
## **PresentationML (PPTX, XML)**
### **A PresentationML-ről**
PresentationML egy XML-alapú formátumcsalád neve a prezentációs dokumentumokhoz. Az Office OpenXML (OOXML) a Microsoft Office 2007 alkalmazásokban bevezetett XML-alapú formátum. Az Office OpenXML több speciális XML-alapú leírónyelv számára konténerformátum. A PresentationML a Microsoft Office PowerPoint 2007 által a dokumentumok tárolására használt leírónyelv.
### **PresentationML az Aspose.Slides for C++-ban**
Az OOXML PresentationML dokumentumok PPTX fájlokként érkeznek, amelyek tömörített XML csomagok a [OOXML ECMA-376](https://www.ecma-international.org/publications-and-standards/standards/ecma-376/) specifikációknak megfelelően. Az Aspose.Slides for C++ kiterjedten támogatja a PresentationML dokumentumok létrehozását, olvasását, manipulálását és írását. Emellett az Aspose.Slides for C++ képes a PresentationML dokumentumok exportálására különböző széles körben használt dokumentumformátumokba, például PDF, TIFF és XPS. Ez lehetséges, mivel az Aspose.Slides for C++ úgy lett tervezve, hogy átfogóan kezelje a prezentációs dokumentumokat, és a PresentationML gyakorlatilag a dokumentumok belső prezentációját tárolja tömörített XML csomagként.

A PPTX dokumentum, amelyet az Aspose.Slides for C++ generált, és a Microsoft PowerPoint-ben megnyitott

Aspose.Slides for C++ által generált PPTX dokumentum megtekintése ZIP alkalmazásban
### **A PresentationML nyílt, miért használjuk az Aspose.Slides for C++-t**
Mivel a PresentationML XML-alapú, teljesen lehetséges alkalmazásokat építeni a PresentationML dokumentumok feldolgozására és előállítására XML osztályok használatával, anélkül hogy harmadik fél könyvtárakra, például az Aspose.Slides for C++-ra támaszkodnánk. Azonban több előny is van az Aspose.Slides for C++ használatában az XML osztályokhoz képest a PresentationML dokumentumok kezelésénél.

Az OOXML specifikáció több ezer oldalra terjed ki. Ez azt jelenti, hogy a PresentationML dokumentumok megfelelő kezeléséhez sok időt és erőfeszítést kell fordítani a formátum megértésére. Másrészt, az Aspose.Slides for C++ használatával egyszerűen csak a megfelelő osztályokat és azok metódusait/tulajdonságait kell használni a műveletekhez, amelyek XML osztályokkal elvégzve meglehetősen összetettek.

A következő funkciók néhány közül, amelyek még nem érhetők el a PresentationML dokumentumok XML osztályokkal történő kezelésekor:
- PPT-dokumentumok exportálása PDF, TIFF, XPS formátumokba
- Dia exportálása a PPT-dokumentumokban SVG formátumba
- Dia renderelése a C++ Framework által támogatott bármely képfformátumba
- Mesterek automatikus másolása a forrásprezentációkból klónozási funkcióval
- Védelem alkalmazása az alakzatokra

Vegyünk egy példát egy PresentationML dokumentumra, amely egyetlen diát tartalmaz egy szövegdobozban a „Hello World” szöveggel. A szöveg XML osztályokkal történő beolvasásához egy programot kell írni, amely ezt az egyszerű szöveget a következő fragmentumból parszi:

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
## **PPT → PPTX konverzió**
### **Az átalakításról**
Az Aspose.Slides most már támogatja a PPT PPTX formátumba konvertálását is.
### **A konverzió támogatott funkciói**
Aspose.Slides for C++ részleges támogatást nyújt a PPT-dokumentumok PPTX formátumú prezentációkká konvertálásához. Mivel a említett prezentációkonverziós funkció csak most került bevezetésre az Aspose.Slides for C++-ban, jelenleg korlátozott képességekkel rendelkezik, és csak egyszerű prezentációkra működik. Az Aspose.Slides for C++ API könyvtár fő előnye a PPT-prezentációk PPTX formátumba konvertálásához az API könnyű használata a kívánt cél eléréséhez. Kérjük, lépjen tovább ehhez[link]() a kódrészletek szakaszhoz további részletekért. A következő szakasz egyértelműen bemutatja, mely funkciók támogatottak és melyek nem támogatottak a PPT formátumú prezentációk PPTX formátumba konvertálásakor.
### **Támogatott funkciók**
A konverzió során a következő funkciók támogatottak:
- Mesterek, elrendezések és diák struktúrájának konvertálása
- Mesterek, elrendezések és diák struktúrájának konvertálása
- Diagramok konvertálása
- Csoport alakzatok
- Auto-alakzatok, többek között téglalapok és ellipszisek konvertálása. Lehet, hogy az auto-alakzatok rossz beállítási értékekkel rendelkeznek.
- Egyéni geometriájú alakzatok. Néha nem konvertálhatók.
- Textúrák és képek kitöltési stílusa auto-alakzatokhoz. Néha nem konvertálhatók.
- Helyőrzők konvertálása
- Szöveg konvertálása szövegkeretekben és szövegtartókban. A listajelek, igazítás és tabulálások nem teljesen implementáltak.
### **Nem támogatott funkciók**
A következő funkciók nem támogatottak a konverzió során:
- Dia jegyzetekkel, mivel a jegyzetek olvasása nem implementált a PPTX-ben. Ha a PPT rendelkezik vele, akkor még nem lehet PPTX-be menteni.
- Vonalak és poligonvonalak konvertálása
- Vonal és kitöltés formátumok
- Gradiens kitöltési stílusok
- OLE keretek, táblázatok, videó- és audio keretek stb.
- Animációk és egyéb diavetítés tulajdonságok kihagyva

Új vagy hiányzó funkciók kerülnek hozzáadásra a jövőbeni Aspose.Slides for C++ kiadásokban.

Forrás PPT prezentáció

Átalakított PPTX prezentáció
## **Portable Document Format (PDF)**
### **A PDF-ről**
A [Portable Document Format](https://en.wikipedia.org/wiki/PDF) egy olyan fájlformátum, amelyet az Adobe System hozott létre dokumentumok cseréjéhez különböző szervezetek között. Ennek a formátumnak a célja, hogy a dokumentumok tartalma úgy legyen ábrázolva, hogy a vizuális megjelenés ne függjön a megtekintés platformjától.
### **PDF az Aspose.Slides for C++-ban**
Bármely prezentációs dokumentum, amely betölthető az Aspose.Slides for C++-ba, konvertálható PDF dokumentummá, amely megfelel a [PDF 1.5](https://en.wikipedia.org/wiki/PDF/A) vagy a [PDF /A-1b](https://en.wikipedia.org/wiki/PDF/A) szabványnak, a választásától függően. Az Aspose.Slides for C++ a prezentációs dokumentumokat PDF-be exportálja úgy, hogy a legtöbb esetben az exportált PDF dokumentum szinte megegyezik az eredeti prezentációval. Az Aspose megoldás a következő prezentációs dokumentum-funkciókat támogatja PDF dokumentumokká konvertáláskor:
- Képek, szövegdobozok és egyéb alakzatok
- Szöveg és formázás
- Bekezdések és formázás
- Hiperhivatkozások
- Fejléc és lábléc
- Listaelemek
- Táblázatok

A prezentációs dokumentum PDF-be történő exportálásához közvetlenül használhatja az Aspose.Slides for C++ összetevőt. Ehhez nincs szükség semmilyen harmadik fél vagy Aspose.Pdf összetevőre. Továbbá, a prezentáció PDF exportálását különböző beállításokkal testreszabhatja, ahogy az [ez a téma](/slides/hu/cpp/convert-powerpoint-to-pdf/) leírásában.

A prezentációs dokumentum PDF-dokumentummá konvertálva az Aspose.Slides for C++ segítségével
## **XML Parser Specification (XPS)**
### **Az XPS-ről**
Az [XML Parser Specification](https://en.wikipedia.org/wiki/Open_XML_Paper_Specification) egy oldalleíró nyelv és egy rögzített dokumentum formátum, amelyet eredetileg a Microsoft fejlesztett. A PDF-hez hasonlóan, az XPS egy rögzített elrendezésű dokumentumformátum, amelyet a dokumentum hűség megőrzésére és az eszközfüggetlen megjelenés biztosítására terveztek.
### **XPS az Aspose.Slides for C++-ban**
Bármely prezentációs dokumentum, amely betölthető az Aspose.Slides for C++-val, konvertálható XPS formátumba. Az Aspose.Slides for C++ a magas hűségű oldalelrendezési és renderelőmotorját használja, hogy kimenetet állítson elő rögzített elrendezésű XPS dokumentum formátumban. Érdemes megemlíteni, hogy az Aspose.Slides for C++ közvetlenül generál XPS-t anélkül, hogy a Windows Presentation Foundation (WPF) osztályokra támaszkodna, melyek a C++ Framework 3.5-ben vannak csomagolva, ezáltal lehetővé téve az Aspose.Slides for C++ számára, hogy XPS dokumentumokat állítson elő olyan gépeken, ahol a C++ Framework 3.5 előtti verziók futnak. Az XPS dokumentumok exportálásáról az Aspose.Slides for C++-val további információkat az [ez a téma](https://docs.aspose.com/slides/hu/cpp/convert-powerpoint-to-xps/) tartalmaz.

Egy prezentációs dokumentum XPS dokumentummá konvertálva az Aspose.Slides for C++ segítségével