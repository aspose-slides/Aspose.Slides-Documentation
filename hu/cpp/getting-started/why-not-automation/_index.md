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
- skálázhatóság
- funkciók
- PowerPoint
- OpenDocument
- prezentáció
- C++
- Aspose.Slides
description: "Fedezze fel, miért kockázatos az Office automatizálás a szerverek és szolgáltatások számára, és lássa, hogyan nyújt az Aspose.Slides biztonságosabb, gyorsabb prezentációfeldolgozást a PowerPoint és az OpenDocument esetében."
---
## **Bevezetés**

Az Aspose összetevők több okból is jobb alternatívát jelentenek az automatizálás helyett. A legfontosabb okok a következők:

- Biztonság
- Stabilitás
- Skálázhatóság/gyorsaság
- Ár
- Funkciók

Az alábbiakban részletesebb magyarázatot talál minden egyes kulcsponthoz.

## **Fontos kérdések**
- Miért jelent az Aspose összetevők jóval jobb lehetőséget, mint a Microsoft Office automatizálás?

Az Aspose-nál leggyakrabban két kérdéssel találkozunk :

- IGÉNYELIK-E termékeink, hogy a Microsoft Office telepítve legyen ahhoz, hogy működjenek?

A rövid egyszerű válasz **NEM**. Az Aspose és az Aspose összetevők teljesen függetlenek, és nem állnak kapcsolatban, illetve nem engedélyezettek, támogatottak vagy bármilyen módon jóváhagyottak a Microsoft Corporation által.

- Miért kellene az Aspose termékeket használni a Microsoft Office automatizálás helyett?

A legrövidebb válasz, amit adhatunk, hogy számos indok van, a legfontosabb, hogy *Microsoft maga erősen javasolja, hogy a szoftveres megoldások ne használjanak Office automatizálást*: [Microsoft Article

## **Biztonság**
Az alábbi idézet a fent hivatkozott Microsoft cikkből származik:
> *Az Office‑alkalmazásokat soha nem tervezték szerver‑oldali használatra, ezért nem veszik figyelembe a megosztott összetevők által szembesülő biztonsági problémákat. Az Office nem hitelesíti a bejövő kéréseket, és nem védi meg a felhasználót attól, hogy véletlenül makrókat futtasson, vagy egy másik szervert indítson el, amely makrókat futtathat a szerver‑oldali kódból. Ne nyisson meg olyan fájlokat, amelyeket egy névtelen webes felhasználó töltött fel a szerverre! A legutóbb beállított biztonsági beállítások alapján a szerver makrókat futtathat egy Administrator vagy System kontextusban teljes jogosultságokkal, és veszélyeztetheti a hálózatot! Ezen felül az Office sok kliens‑oldali összetevőt használ (például Simple MAPI, WinInet, MSDAIPP), amelyek a feldolgozás gyorsítása érdekében a kliens hitelesítési adatait cache‑lik. Ha az Office‑t szerver‑oldalon automatizálják, egy példány több ügyfél kiszolgálására is alkalmas lehet, és mivel a hitelesítési információk a munkamenethez cache‑lve vannak, előfordulhat, hogy egy ügyfél a másik kliens cache‑elt hitelesítő adatait használja, és ezzel jogosulatlan hozzáférési jogokat szerez más felhasználók személyében.*  

Az Aspose termékek nagyon biztonságosak. Ezért az Aspose összetevők nem jelentenek kockázatot a kritikus rendszererőforrásokra. Ezen felül, amikor egy dokumentumot egy Aspose összetevő nyit meg, a makrók nem futnak automatikusan. Az Aspose összetevőket úgy tervezték, hogy a fejlesztők létrehozhassanak, módosíthassanak és menthessenek Office‑fájlokat. A Microsoft Office csomaghoz kapcsolódó kockázatok nem állnak fenn az Aspose összetevőkben.

## **Stabilitás**
Az alábbi idézet a fent hivatkozott Microsoft cikkből származik:
> *Az Office 2000, Office XP és Office 2003 a Microsoft Windows Installer (MSI) technológiát használja a telepítés és az önjavítás egyszerűsítésére a végfelhasználó számára. Az MSI bevezeti a „install on first use” (első használatkor telepítés) koncepciót, amely lehetővé teszi a funkciók dinamikus telepítését vagy konfigurálását futásidőben (a rendszer vagy gyakran egy adott felhasználó számára). Egy szerver‑oldali környezetben ez lassítja a teljesítményt, és növeli annak valószínűségét, hogy megjelenik egy párbeszédablak, amely a felhasználót a telepítés jóváhagyására vagy egy megfelelő telepítőlemez biztosítására kéri. Noha az MSI‑t a Office felhasználói termékként történő ellenálló képességének növelésére tervezték, az Office MSI‑képességeinek megvalósítása kontraproduktív egy szerver‑oldali környezetben. Ráadásul az Office általános stabilitása nem garantálható szerver‑oldali futtatáskor, mivel nem lett erre a felhasználási módra tervezve vagy tesztelve. Az Office hálózati szerveren szolgáltató komponensként való használata csökkentheti a gép stabilitását, és ezáltal az egész hálózatét is. Ha Office‑t szeretne szerver‑oldalon automatizálni, próbálja meg elkülöníteni a programot egy dedikált számítógépre, amely nem befolyásolhat kritikus funkciókat, és amely szükség esetén újraindítható.*  

Mivel az Aspose összetevők egyetlen DLL‑be vannak csomagolva, soha nem lesz szükség további részek vagy egységek telepítésére a működésükhöz. Az Aspose összetevőket csak C++ alkalmazások használják, és nincs olyan kódrészlet, amely emberi válaszra várna. Az Aspose összetevőket alaposan tesztelték és rendkívül stabilak. Az Aspose összetevőket használják [Cégek](https://about.aspose.com/customers) közül például **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** és még sokan mások.

## **Skálázhatóság/gyorsaság**
Az alábbi idézet a fent hivatkozott Microsoft cikkből származik:
> *A szerver‑oldali összetevőknek nagyon újra‑beléphetőnek, többszálú COM‑összetevőknek kell lenniük, minimális terheléssel és magas áteresztőképességgel több kliens számára. Az Office‑alkalmazások ezzel szemben szinte minden tekintetben az ellentétesek. Nem újra‑beléphetők, STA‑alapú automatizálási szerverek, melyek egyetlen kliens számára bonyolult, erőforrás‑igényes funkciókat biztosítanak. Korlátozott a skálázhatóságuk szerver‑oldali megoldásként, és fontos elemek, mint a memória, rögzített korlátokkal rendelkeznek, amelyek konfigurációval nem módosíthatók. Ami még fontosabb, globális erőforrásokat használnak (például memóriatérképes fájlok, globális bővítmények vagy sablonok, valamint megosztott automatizálási szerverek), ami korlátozhatja az egyszerre futtatható példányok számát, és versenyhelyzetekhez vezethet, ha több‑kliens környezetben van beállítva. Azok a fejlesztők, akik egyszerre több példányt szeretnének futtatni bármely Office‑alkalmazásból, fontolóra kell vegyék a pool‑ozást vagy a szekvenciális hozzáférést az Office‑alkalmazáshoz a lehetséges holtpontok vagy adatkorruptálás elkerülése érdekében.*  

Az Aspose összetevők nagyon skálázhatóak és villámgyorsak. Az Office‑alkalmazásokat nem arra tervezték, hogy egyszerre több száz vagy több ezer felhasználó használja őket. Az Aspose összetevők e célra lettek kialakítva. Komponenseink valódi C++ megoldást jelentenek, és hibátlanul működnek akár egyetlen szerveren, egyetlen alkalmazás támogatására, akár egy terhelés‑kiegyenlítő Web Formon, amely vállalati szintű alkalmazást hajt.

## **Ár**
Amikor egy alkalmazás a Microsoft Office automatizálást használja, a Microsoft Office egy példányát minden gépre meg kell vásárolni, amelyen az alkalmazás fut. Számos esetben egy alkalmazásnak csak fájlok létrehozására vagy módosítására van szüksége, anélkül, hogy a felhasználónak Microsoft Office‑nak kellene lennie. Az Aspose nagyon [Költséghatékony](https://purchase.aspose.com/) és jogdíjmentes terjesztési licencet kínál, amely korlátlan számú felhasználó számára engedélyezi a telepítést licencelési aggályok nélkül.   
Web‑alapú alkalmazások létrehozásakor fontos tudni, hogy a Microsoft Office automatizálási összetevők sem árazottak, sem nem licenceltek szerver‑oldali megoldásokra; ezért nincs megfelelő licencelési megoldás a MS Office‑összetevőket használó web‑alkalmazások telepítésére. Az Aspose szintén nagyon [Költséghatékony](https://purchase.aspose.com/) megoldást kínál szerver‑oldali alkalmazásokhoz.

## **Funkciók**
Az Aspose összetevők mindent biztosítanak az Office‑fájlok kezeléséhez, és még annál is többet. Olyan filozófiával lettek megtervezve, amely lehetővé teszi a fejlesztők számára, hogy a legnagyobb eredményt a legkevesebb munkával érjék el. Az Office‑automatizálással ellentétben az Aspose összetevők sok erőteljes és időt megtakarító funkciót kínálnak. Például az [Aspose.Cells](https://products.aspose.com/cells/cpp/) lehetővé teszi a fejlesztők számára, hogy **DataTable**‑ből vagy **DataView**‑ból közvetlenül importáljanak adatokat egy Excel‑fájlba. Az [Aspose.Words](https://products.aspose.com/words/net/) hasonló funkciót kínál, amely lehetővé teszi a fejlesztőknek, hogy egy Word (Mail Merge) dokumentumot közvetlenül bármely C++ adatobjektumból töltse fel. A [Minden komponens](https://products.aspose.com/total/cpp/) az Aspose családban saját, egyedi és erőteljes funkciókkal rendelkezik.  
Az Aspose komponens megvásárlásának legjobb része, hogy hozzáférést kap fejlesztői csapatunkhoz. Fejlesztői csapatunk tisztában van azzal, hogy ha egy funkcióra a vállalatuknak szüksége van, valószínűleg más vállalatoknak is szükségük lesz rá. Bár nem minden funkciókérést lehet beépíteni, csapatunk nagyon nyitott és rugalmas a segítségnyújtás során. Ez a gondolkodásmód segítette, hogy az Aspose összetevők annyira erőteljesek legyenek. Ha további funkciókra van szüksége az Office‑automatizálási objektumokból, az esélye, hogy ezeket hozzáadják, nagyon, nagyon alacsony.

## **Következtetés**
{{% alert color="primary" %}} 

Bár ez a cikk számos kulcsfontosságú pontot lefed, amelyért az Aspose összetevők jobb választásként szerepelnek az Office‑automatizálással szemben, még sok, sok más előny is létezik. Ez a cikk elsősorban a legfontosabb pontokra koncentrál. Minden Aspose összetevő kockázatmentes, kötelezettség nélküli [Értékelő változatot](https://downloads.aspose.com/slides/hu/cpp) kínál. Javasoljuk, hogy használja ki ezt az [Értékelést](https://downloads.aspose.com/slides/hu/cpp), hogy jobban lássa, mit tud nyújtani az Aspose az Ön alkalmazásai számára.