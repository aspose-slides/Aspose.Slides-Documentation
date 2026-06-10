---
title: Miért ne használjunk automatizálást
type: docs
weight: 50
url: /hu/php-java/why-not-automation/
keywords:
- automatizálás
- Microsoft Office
- összehasonlítás
- biztonság
- stabilitás
- skálázhatóság
- funkciók
- PowerPoint
- OpenDocument
- bemutató
- PHP
- Aspose.Slides
description: "Fedezze fel, miért kockázatos az Office automatizálás a szerverek és szolgáltatások számára, és lássa, hogyan biztosít az Aspose.Slides biztonságosabb, gyorsabb bemutatófeldolgozást a PowerPoint és az OpenDocument esetén."
---
## **Áttekintés**

Számos oka van annak, hogy az Aspose komponensek jobb alternatívát jelentenek az automatizálásnál. A legfontosabb okok a következők:

- Biztonság
- Stabilitás
- Skálázhatóság/Sebesség
- Ár
- Funkciók

Alább részletesebb magyarázatot talál a minden egyes kulcspontról.

## **Fontos kérdések**

Két kérdés van, amelyet gyakran hallunk az Aspose-nél:

- A termékeiknek szükséges a Microsoft Office telepítése a futtatáshoz?

A rövid, egyszerű válasz **NEM**.

- Miért kellene az Aspose termékeket használnunk a Microsoft Office automatizálás helyett?

Először is, számos [Az Aspose.Slides használatakor élvezhető előnyök](/slides/hu/php-java/product-overview/) vannak.

Másodszor, a Microsoft maga erősen **ellenez** a szoftveres megoldásokból származó Office automatizálás használatát.

## **Biztonság**

Az alábbi idézet közvetlenül egy Microsoft cikkből származik:

*"Az Office alkalmazásokat soha nem tervezték szerveroldali használatra, így nem veszik figyelembe a elosztott komponensek által tapasztalt biztonsági problémákat. Az Office nem hitelesíti a bejövő kéréseket, és nem védi meg a felhasználót a makrók véletlen futtatásától, illetve egy másik szerver indításától, amely makrókat futtathat a szerveroldali kódból. Ne nyisson meg olyan fájlokat, amelyeket egy anonim webről töltöttek fel a szerverre! A legutóbb beállított biztonsági beállítások alapján a szerver makrókat futtathat egy Administrator vagy System környezetben teljes jogosultságokkal, és veszélyeztetheti a hálózatot! Ezen felül az Office számos kliensoldali komponenst (például Simple MAPI, WinInet, MSDAIPP) használ, amelyek a gyorsabb feldolgozás érdekében cache-elik a kliens hitelesítési információkat. Ha az Office szerveroldalon van automatizálva, egy példány több ügyfélt is kiszolgálhat, és mivel a hitelesítési információk a munkamenethez cache-elve vannak, előfordulhat, hogy egy ügyfél a másik ügyfél cache-elt hitelesítő adatait használja, és ezáltal jogosulatlan hozzáférési engedélyeket szerez más felhasználók személyének felvételével."*

Aspose termékek nagyon biztonságosak. Az Aspose komponensek nem jelentenek potenciális kockázatot a létfontosságú rendszer erőforrásokra. Ráadásul, amikor egy dokumentumot egy Aspose komponens nyit meg, a makrók nem futnak automatikusan. Az Aspose komponenseket azzal a céllal fejlesztették ki, hogy a fejlesztők Office fájlokat hozhassanak létre, módosíthassanak és menthessenek. A Microsoft Office csomaghoz kapcsolódó kockázatok nem jelennek meg az Aspose komponenseknél.

## **Stabilitás**

Az alábbi idézet közvetlenül egy Microsoft cikkből származik:

*"Az Office 2000, Office XP és Office 2003 a Microsoft Windows Installer (MSI) technológiát használja a telepítés és az önjavítás egyszerűbbé tételéhez a végfelhasználó számára. Az MSI bevezeti a „telepítés első használatkor” koncepciót, amely lehetővé teszi a funkciók dinamikus telepítését vagy konfigurálását futásidőben (rendszer számára, vagy gyakrabban egy adott felhasználó számára). Egy szerveroldali környezetben ez egyszerre lassítja a teljesítményt és növeli annak valószínűségét, hogy megjelenik egy párbeszédpanel, amely a felhasználótól a telepítés jóváhagyását vagy egy megfelelő telepítőlemez megadását kéri. Bár az Office felhasználói termékként való megbízhatóságának növelésére tervezték, az Office MSI képességeinek megvalósítása szerveroldali környezetben kontraproduktív. Továbbá, az Office általános stabilitása nem garantálható szerveroldalon történő futtatás esetén, mivel nem lett tervezve vagy tesztelve ilyen használatra. Az Office szolgáltatásként való használata egy hálózati szerveren csökkentheti a gép stabilitását, és ennek következtében az egész hálózatét. Ha az Office szerveroldali automatizálását tervezi, próbálja izolálni a programot egy dedikált számítógépre, amely nem befolyásolhat kritikus funkciókat, és amelyet szükség szerint újraindíthat."*

Az Aspose komponenseket alaposan tesztelték és rendkívül stabilak. Az Aspose komponenseket olyan [Cégek](https://about.aspose.com/customers) használják, mint: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** és még sok-sok más.

## **Skálázhatóság/Sebesség**

Az alábbi idézet közvetlenül egy Microsoft cikkből származik:

*"A szerveroldali komponenseknek nagy fokú újrahívhatósággal, több szálon futó COM komponensekkel kell rendelkezniük, minimális terheléssel és magas áteresztőképességgel több ügyfél számára. Az Office alkalmazások szinte minden tekintetben az ellenkezőjét jelentik. Nem újrahívhatóak, STA-alapú Automatizálási szerverek, amelyeket egyetlen ügyfél számára terveztek, sokféle, de erőforrásigényes funkcióval. Kevés skálázhatóságot kínálnak szerveroldali megoldásként, és rögzített korlátokkal rendelkeznek fontos elemekre, mint például a memória, amelyeket nem lehet konfigurációval megváltoztatni. Még fontosabb, hogy globális erőforrásokat (például memóriatérképes fájlok, globális kiegészítők vagy sablonok, valamint megosztott Automatizálási szerverek) használnak, amelyek korlátozhatják a párhuzamosan futtatható példányok számát, és versenyhelyzetekhez vezethetnek, ha több ügyfél környezetben vannak konfigurálva. Azok a fejlesztők, akik egyszerre több példányt kívánnak futtatni bármely Office alkalmazásból, meg kell fontolják a * ***Pooling*** * vagy a * ***Serializing Access*** * használatát az Office alkalmazáshoz, hogy elkerüljék a potenciális * ***Deadlocks*** * vagy a * ***Data Corruption*** * .*

Az Aspose komponensek nagyon skálázhatóak és villámgyorsak. Az Office alkalmazásokat nem arra tervezték, hogy egyszerre több száz vagy ezer felhasználó használja. Azonban az Aspose komponenseket kifejezetten erre tervezték. Komponenseink hibátlanul működnek akár egyetlen szerveren, egyetlen alkalmazást támogatva, akár egy terheléselosztó Web űrlapon, amely vállalati szintű alkalmazást hajt.

## **Ár**

Amikor egy alkalmazás a Microsoft Office Automatizálást használja, a Microsoft Office egy példányát minden olyan géphez meg kell vásárolni, amelyen az alkalmazás fut. Sok esetben az alkalmazásnak szüksége lehet irodai fájl létrehozására vagy módosítására, anélkül, hogy a felhasználónak Microsoft Office-ra lenne szüksége. Az Aspose nagyon [Költséghatékony](https://purchase.aspose.com/) és jogdíjmentes újraelosztási licencet kínál, amely lehetővé teszi a korlátlan számú felhasználó számára történő telepítést licencelési aggályok nélkül.

Webalapú alkalmazások készítésekor fontos tudni, hogy a Microsoft Office Automatizálási komponensek nem árazottak és nem licenceltek szerveroldali megoldásokra; ezért nincs jó licencmegoldás a Microsoft Office komponenseket használó webalkalmazások telepítésére. Az Aspose szintén nagyon költséghatékony megoldást kínál szerveroldali alkalmazásokhoz.

## **Funkciók**

Az Aspose komponensek mindent biztosítanak az Office fájlok kezeléséhez, és még sok mást is. Úgy lettek tervezve, hogy a fejlesztők a lehető legkevesebb munka befektetésével érjék el a legjobb eredményeket. Az Office Automatizálással ellentétben az Aspose komponensek számos erőteljes és időt takarító funkciót nyújtanak. Például az [Aspose.Cells](https://products.aspose.com/cells/php-java/) lehetővé teszi a fejlesztők számára, hogy adatokat **DataTable** vagy **DataView** objektumból importáljanak közvetlenül egy Excel fájlba. [Minden komponens](https://products.aspose.com/total/php-java/) az Aspose családban saját egyedi és erőteljes funkciókészlettel rendelkezik.

Az Aspose komponens (vagy olyan komponenscsomagok, mint a [Aspose.Total](https://products.aspose.com/total/php-java/)) megvásárlásának legjobb része, hogy hozzáférünk fejlesztői csapatainkhoz. Fejlesztői csapataink felismerik, hogy ha a vállalatodnak szüksége van egy bizonyos funkcióra, valószínűleg más cégeknek is szükségük lesz rá. Bár nem minden funkciókérést lehet megvalósítani, csapatunk nagyon nyitott és rugalmas a segítségnyújtás során. Ez a szemlélet segítette, hogy az Aspose komponensek olyan erőteljesek legyenek, mint amilyenek. Ha további funkciókra van szükséged az Office Automatizálási objektumokból, a hozzáadásuk esélye nagyon, nagyon alacsony.

## **Következtetés**
{{% alert color="primary" %}} 

Bár ez a cikk számos kulcspontot lefed, amiért az Aspose komponensek jobb választásnak bizonyulnak, mint az Office Automatizálás, még rengeteg más ok is van. Ez a cikk elsősorban csak a legfontosabb pontokra fókuszál. Az összes különböző Aspose komponens kockázatmentes, kötelezettség nélküli [Értékelő Verziót](https://downloads.aspose.com/slides/hu/java) kínál. Bátorítjuk, hogy használja ki ezt az Értékelést, hogy jobban lássa, mit tud nyújtani az Aspose az alkalmazásai számára. 

{{% /alert %}}