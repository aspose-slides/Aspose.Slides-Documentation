---
title: Miért ne használjunk automatizálást
type: docs
weight: 50
url: /hu/cpp/why-not-automation/
keywords:
- automatizálás
- Microsoft Office
- összehasonlítás
- biztonság
- stabilitás
- méretezhetőség
- funkciók
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel, miért kockázatos az Office automatizálása a szerverek és szolgáltatások számára, és lássa, hogyan kínál az Aspose.Slides biztonságosabb, gyorsabb prezentációfeldolgozást a PowerPoint és az OpenDocument esetében."
---
## **Bevezetés**

Számos oka van annak, hogy az Aspose komponensek jobb alternatívát jelentenek az automatizálásnál. A legfontosabb okok a következők:

- Biztonság
- Stabilitás
- Méretezhetőség / Sebesség
- Ár
- Funkciók

Az alább részletesebb magyarázatot talál minden egyes kulcsponthoz.

## **Fontos kérdések**
- Miért jelent az Aspose komponensek sokkal jobb lehetőséget, mint a Microsoft Office automatizálás?

Két kérdés van, amelyet a leggyakrabban hallunk az Aspose-nál :

- Megköveteli a termékeiknek, hogy a Microsoft Office telepítve legyen a működéshez?

A rövid egyszerű válasz **NEM**. Az Aspose és az Aspose komponensek teljesen függetlenek, és nincs kapcsolatuk, sem engedélye, szponzorálás vagy bármilyen jóváhagyás a Microsoft Corporation részéről.

- Miért kellene az Aspose termékeket használnunk a Microsoft Office automatizálás helyett?

A legrövidebb válasz, amit adhatunk, hogy sok oka van, legfontosabb, hogy a *Microsoft maga erősen javasolja, hogy a szoftveres megoldások ne használjanak Office automatizálást*: [Microsoft Article

## **Biztonság**
Az alábbi közvetlen idézet a fent hivatkozott Microsoft cikkből: 
*"Az Office alkalmazások soha nem voltak tervezve szerveroldali használatra, ezért nem veszik figyelembe a terjesztett komponensek által felmerülő biztonsági problémákat. Az Office nem hitelesíti a bejövő kéréseket, és nem védi Önt attól, hogy véletlenül makrókat futtasson, vagy egy másik szervert indítson, amely makrókat futtathat a szerveroldali kódjából. Ne nyisson meg olyan fájlokat, amelyeket egy anonim webről töltöttek fel a szerverre! A legutóbb beállított biztonsági beállítások alapján a szerver makrókat futtathat egy Administrator vagy System környezetben teljes jogosultsággal, és veszélyeztetheti hálózatát! Ezen felül az Office sok kliensoldali komponenst (például Simple MAPI, WinInet, MSDAIPP) használ, amelyek a feldolgozás felgyorsítása érdekében cache‑elik a kliens hitelesítési információkat. Ha az Office szerveroldalon van automatizálva, egy példány több kliensnek is kiszolgálhat, és mivel a hitelesítési információk erre a munkamenetre cache‑elve lettek, előfordulhat, hogy egy kliens a másik kliens cache‑elt hitelesítő adatait használva, nem engedélyezett hozzáférési jogosultságokat szerez, más felhasználóként azonosítva magát."*

Az Aspose termékek nagyon biztonságosak. Ennek eredményeként az Aspose komponensek nem jelentenek potenciális kockázatot a létfontosságú rendszer erőforrásokra. Továbbá, amikor egy dokumentumot egy Aspose komponens nyit meg, a makrók nem futnak automatikusan. Az Aspose komponenseket úgy hozták létre, hogy a fejlesztők Office fájlokat hozhassanak létre, módosíthassanak és menthessenek. A Microsoft Office csomaghoz kapcsolódó kockázatok egyike sem áll fenn az Aspose komponenseknél.

## **Stabilitás**
Az alábbi közvetlen idézet a fent hivatkozott Microsoft cikkből: 
*"Az Office 2000, Office XP és Office 2003 a Microsoft Windows Installer (MSI) technológiát használja az installáció és az önjavítás egyszerűbbé tételéhez a végfelhasználó számára. Az MSI bevezeti az „install on first use” (első használatkor történő telepítés) koncepcióját, amely lehetővé teszi a funkciók dinamikus telepítését vagy konfigurálását futásidőben (a rendszer vagy gyakrabban egy adott felhasználó számára). Egy szerveroldali környezetben ez lassítja a teljesítményt és növeli annak valószínűségét, hogy egy párbeszédablak jelenik meg, amely a felhasználótól engedélyt kér a telepítéshez vagy megfelelő telepítőlemezt kér. Bár az Office végfelhasználói termékként való megszilárdítására tervezték, az Office MSI képességeinek megvalósítása ellentétes a szerveroldali környezettel. Ezen felül az Office általános stabilitása nem garantálható szerveroldalon, mivel nem tervezett vagy tesztelt ilyen használatra. Az Office hálózati szerveren szolgáltatáskomponensként való használata csökkentheti az adott gép stabilitását, és ennek következtében az egész hálózat stabilitását is. Ha az Office szerveroldali automatizálását tervezi, próbálja elválasztani a programot egy dedikált számítógépre, amely nem befolyásolhat kritikus funkciókat, és amelyet szükség esetén újra lehet indítani."*

Mivel az Aspose komponensek egyetlen DLL-be vannak csomagolva, soha nem lesz szükség további részek vagy darabok telepítésére a működésükhöz. Az Aspose komponenseket csak C++ alkalmazások használják, és nincs olyan része a komponenskódnak, amely emberi válaszra várna. Az Aspose komponenseket alaposan tesztelték, és rendkívül stabilak. Az Aspose komponenseket használja [Companies](https://about.aspose.com/customers) olyan cégek, mint: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** és még sokan.

## **Méretezhetőség / Sebesség**
Az alábbi közvetlen idézet a fent hivatkozott Microsoft cikkből: 
*"A szerveroldali komponenseknek rendkívül újrahasználhatónak (reentrant), több szálon futó COM komponenseknek kell lenniük, minimális terheléssel és magas áteresztőképességgel több ügyfél esetén. Az Office alkalmazások szinte minden tekintetben az ezzel ellentétesek. Nem újrahasználhatók, STA‑alapú automatizálási szerverek, amelyek egyetlen ügyfél számára nyújtanak sokféle, erőforrás-igényes funkciót. Kevés a skálázhatóságuk szerveroldali megoldásként, és rögzített korlátokkal rendelkeznek fontos elemekre, például memóriára, amelyet nem lehet konfigurációval módosítani. Még fontosabb, hogy globális erőforrásokat (például memóriatérképes fájlok, globális kiegészítők vagy sablonok, valamint megosztott automatizálási szerverek) használnak, ami korlátozhatja az egyidejűleg futtatható példányok számát, és versenyhelyzeteket idézhet elő, ha több ügyfél környezetben vannak konfigurálva. A fejlesztők, akik egyszerre több példányt akarnak futtatni bármely Office alkalmazásból, fontolóra kell vegyék a poololást vagy a szekvenciális hozzáférést az Office alkalmazáshoz a lehetséges holtpontok vagy adatkorruptió elkerülése érdekében.”*

Az Aspose komponensek rendkívül méretezhetők és villámgyorsak. Az Office alkalmazások nem lettek úgy tervezve, hogy egyszerre 100‑as, 1000‑es felhasználók használják őket. Az Aspose komponensek pontosan erre lettek tervezve. Komponenseink valódi C++ megoldást nyújtanak, és hibátlanul működnek akár egyetlen szerveren, egy alkalmazás táplálására, akár egy terheléselosztott webes űrlapon, amely vállalati szintű alkalmazást támogat.

## **Ár**
Ha egy alkalmazás a Microsoft Office automatizálást használja, akkor minden gépre meg kell vásárolni a Microsoft Office egy példányát, amely az alkalmazást futtatja. Sok esetben az alkalmazásnak szüksége van egy Office fájl létrehozására vagy módosítására, anélkül, hogy a felhasználónak a Microsoft Office legyen telepítve. Az Aspose nagyon [Cost Effective](https://purchase.aspose.com/) és royalty‑free újraelosztási licencet kínál, amely lehetővé teszi a korlátlan felhasználószámú telepítést licencelési gondok nélkül. Web‑alapú alkalmazások készítésekor fontos tudni, hogy a Microsoft Office Automatizálási komponensek nem árazottak és nem licenceltek szerveroldali megoldásokra; ezért nincs megfelelő licencelési megoldás a Microsoft Office komponenseket használó webalkalmazások telepítésére. Az Aspose nagyon [Cost Effective](https://purchase.aspose.com/) megoldást kínál szerver‑alapú alkalmazásokhoz is.

## **Funkciók**
Aspose komponensek minden szükséges funkciót biztosítanak az Office fájlok kezeléséhez, sőt még többet. Úgy lettek tervezve, hogy a fejlesztők a legkevesebb erőfeszítéssel érjék el a legjobb eredményeket. Az Office automatizálással szemben az Aspose komponensek sok erőteljes és időt takarító funkciót kínálnak. Például a [Aspose.Cells](https://products.aspose.com/cells/cpp/) lehetővé teszi a fejlesztők számára, hogy egy **DataTable**‑ből vagy **DataView**‑ból közvetlenül importáljanak adatokat egy Excel fájlba. A [Aspose.Words](https://products.aspose.com/words/net/) hasonló funkcióval rendelkezik, amely lehetővé teszi, hogy a fejlesztők egy Word (azaz Mail Merge) dokumentumot közvetlenül bármely C++ adatobjektumból töltsenek fel. Az [Every Component](https://products.aspose.com/total/cpp/) az Aspose családban saját, egyedi és erőteljes funkciókészlettel rendelkezik. Az Aspose komponens megvásárlásának legjobb része, hogy hozzáférést kapunk fejlesztői csapatunkhoz. Fejlesztői csapatunk felismeri, hogy ha egy funkcióra a cégének szüksége van, nagy valószínűséggel más vállalatoknak is szükségük lesz rá. Bár minden funkciókérést nem lehet beépíteni, csapataink nagyon nyitottak és rugalmasak a segítségnyújtás során. Ez a szemlélet segítette, hogy az Aspose komponensek olyan erőteljesek legyenek, mint most. Ha további funkciókat igényel az Office Automatizálási objektumokból, esélye, hogy ezeket hozzáadják, nagyon, nagyon alacsony.

## **Következtetés**
{{% alert color="info" %}} 
Habár ez a cikk számos kulcsfontosságú pontot lefed, amiért az Aspose komponensek jobb választásként szolgálnak, mint az Office automatizálás, sok, sok további is van. A cikk elsősorban csak a legfontosabb pontokat érinti. Az egyes Aspose komponensek kockázatmentes, kötelezettség nélküli [Evaluation Version](https://downloads.aspose.com/slides/hu/cpp) verziót kínálnak. Javasoljuk, hogy használja ki ezt a [Evaluation](https://downloads.aspose.com/slides/hu/cpp) verziót, hogy jobban lássa, mit tud nyújtani az Aspose az alkalmazásai számára.
{{% /alert %}}