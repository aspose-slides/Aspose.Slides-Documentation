---
title: "Miért ne használjunk automatizálást"
type: docs
weight: 40
url: /hu/net/why-not-automation/
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
- bemutató
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel, miért kockázatos az Office automatizálás szerverek és szolgáltatások esetén, és lássa, hogyan biztosít az Aspose.Slides biztonságosabb, gyorsabb prezentációfeldolgozást a PowerPoint és az OpenDocument számára."
---
## **Bevezetés**

Számos oka van annak, hogy az Aspose komponensek jobb alternatívát jelentenek az automatizálásnál. A legfontosabb okok a következők:

- Biztonság
- Stabilitás
- Méretezhetőség/Sebesség
- Ár
- Funkciók

Alább részletesebb magyarázatot talál minden kulcsponthoz.

## **Fontos kérdések**

Két gyakran felmerülő kérdésünk van az Aspose-nál:

- A termékeiknek szükségük van a Microsoft Office telepítésére a futtatáshoz?

A rövid, egyszerű válasz **NEM**.

Az Aspose komponensek teljesen függetlenek, és nem állnak kapcsolatban, nem engedélyezettek, nem szponzoráltak vagy más módon jóváhagyottak a Microsoft Corporation által.

- Miért használjunk Aspose termékeket a Microsoft Office Automatizáció helyett?

Először is számos [előny élvezhető az Aspose.Slides használatával](/slides/hu/net/product-overview/).

Másodszor, a Microsoft maga is erősen **nem ajánlja** az Office Automatizáció használatát szoftveres megoldásokban.

## **Biztonság**
Az alábbi közvetlen idézet egy Microsoft cikkből:

> "Az Office alkalmazásokat soha nem tervezték szerveroldali használatra, ezért nem veszik figyelembe a elosztott komponensek által okozott biztonsági problémákat. Az Office nem hitelesíti a bejövő kéréseket, és nem védi meg a felhasználót a nem szándékolt makrók futtatásától, illetve attól, hogy egy másik szerver indítson el makrókat a szerveroldali kódból. Ne nyisson meg a szerverre feltöltött fájlokat anonim webes forrásból! Az utolsó beállított biztonsági beállítások alapján a szerver makrókat futtathat Administrator vagy System jogosultságokkal, teljes privilégiumokkal, ami veszélyeztetheti a hálózatot! Ezen felül az Office számos kliensoldali komponenst (például Simple MAPI, WinInet, MSDAIPP) használ, amelyek a feldolgozás gyorsítása érdekében cache‑elik a kliens hitelesítési információkat. Ha az Office szerveroldalon van automatizálva, egy példány több kliensnek is kiszolgálhat, és mivel a hitelesítési információk cache‑elve vannak az adott munkamenethez, előfordulhat, hogy egy kliens a másik kliens hitelesítő adatait használja, ezzel jogosulatlan hozzáférési jogosultságokat szerezve más felhasználók személyében."

Az Aspose termékek nagyon **biztonságosak**. Az Aspose komponensek ugyanabban a felhasználói kontextusban futnak, mint minden ASP.NET alkalmazás (az ASPNET felhasználó alatt). Ezért az Aspose komponensek **nem** jelentenek biztonsági kockázatot. Emellett nem fogyasztanak kritikus rendszererőforrásokat. Továbbá, amikor egy Aspose komponens megnyit egy dokumentumot, a makrók nem futnak automatikusan. Az Aspose komponenseket úgy tervezték, hogy a fejlesztők Office fájlokat hozhassanak létre, manipulálhassanak és menthessenek.

{{% alert color="primary" %}} 
Egyik Microsoft Office csomaghoz kapcsolódó kockázat sem vonatkozik az Aspose komponensekre.
{{% /alert %}} 

## **Stabilitás**
Az alábbi közvetlen idézet a korábban hivatkozott Microsoft cikkből:

> "Az Office 2000, Office XP és Office 2003 a Microsoft Windows Installer (MSI) technológiát használja a telepítés és az önjavítás egyszerűbbé tételéhez a végfelhasználó számára. Az MSI bevezeti a „first use” (első használatkor) telepítés koncepcióját, amely lehetővé teszi a funkciók dinamikus telepítését vagy konfigurálását futásidőben (a rendszer, vagy gyakrabban egy adott felhasználó számára). Szerveroldali környezetben ez lassítja a teljesítményt, és megnöveli annak valószínűségét, hogy megjelenjen egy párbeszédpanel, amely a felhasználó jóváhagyását vagy megfelelő telepítőlemez biztosítását kéri. Bár az MSI célja az Office felhasználói termékként történő megbízhatóságának növelése, az Office MSI implementációja kontraproduktív szerveroldali környezetben. Továbbá, az Office általános stabilitása nem garantálható szerveroldalon, mivel nem lett erre a felhasználási módra tervezve vagy tesztelve. Az Office szolgáltatáskomponensként való használata hálózati szerveren csökkentheti a gép stabilitását, és következményében az egész hálózatét. Ha az Office-ot szerveroldalon szeretné automatizálni, próbálja meg egy dedikált számítógépre izolálni, amely nem befolyásolhat kritikus funkciókat, és amely szükség esetén újraindítható."

Mivel az Aspose komponensek egyetlen DLL‑ben vannak csomagolva, felhasználóiknak soha nem kell további részeket vagy alkotóelemeket telepíteniük a működéshez. Az Aspose komponenseket kizárólag .NET alkalmazások használják, és nincs olyan komponenskódrészlet, amely emberi válaszra várna.

{{% alert color="primary" %}} 
Az Aspose komponenseket alaposan tesztelték, és nagyon stabilnak bizonyultak. Az Aspose komponenseket olyan [vállalatok](http://www.aspose.com/Corporate/Aspose/Customerlist.html) használják, mint a **IBM**, **Hilton**, **Reader's Digest**, **Bank of America**, valamint számos más vezető szervezet különböző iparágakban és területeken.
{{% /alert %}} 

## **Méretezhetőség/Sebesség**
Az alábbi közvetlen idézet egy Microsoft cikkből:

> "A szerveroldali komponenseknek magas fokú újrafelhasználhatósággal, több szálon futó COM komponensekkel kell rendelkezniük, minimális terheléssel és nagy áteresztőképességgel több kliens számára. Az Office alkalmazások gyakorlatilag az ellenkezőjét jelentik. Nem újrafelhasználhatóak, STA‑alapú automatizációs szerverek, amelyeket arra terveztek, hogy egyetlen kliens számára nyújtsanak sokféle, erőforrás-igényes funkciót. Kevés skalázhatóságot biztosítanak szerveroldali megoldásként, és rögzített korlátokkal rendelkeznek fontos elemekre, például a memóriára, amelyet konfigurációval nem lehet módosítani. Még fontosabb, hogy globális erőforrásokat (például memória‑térképű fájlok, globális kiegészítők vagy sablonok, valamint megosztott automatizációs szerverek) használnak, ami korlátozhatja az egyidejűleg futtatható példányok számát, és versenyhelyzetekhez vezethet többklienses környezetben. Azok a fejlesztők, akik egyszerre több példányt szeretnének futtatni egy Office alkalmazásból, fontolóra kell vegyék a párolgatást vagy a soros hozzáférést az Office alkalmazáshoz, hogy elkerüljék a lehetséges holtállásokat vagy adatkorruptciót."

Az Aspose komponensek hihetetlenül méretezhetők és villámgyorsak. Az Office alkalmazásokat nem arra tervezték, hogy egyszerre 100‑as vagy 1000‑es felhasználók használják, míg az Aspose komponensek pontosan erre lettek kifejlesztve. Komponenseink valódi .NET megoldást jelentenek.

{{% alert color="primary" %}} 
Az Aspose komponensek teljesítménye hibátlan egyetlen szerveren (egy alkalmazás támogatásával) vagy egy terheléskiegyensúlyozott webformon (vállalati szintű alkalmazás támogatásával).
{{% /alert %}} 

## **Ár**
Amikor egy alkalmazás Microsoft Office automatizációt használ, a Microsoft Office egy példányát minden gépre meg kell vásárolni, amelyen az alkalmazás fut. Sok esetben egy alkalmazásnak office fájlt kell létrehoznia vagy manipulálnia, de a folyamat nem igényli a Microsoft Office‑t.

{{% alert color="primary" %}} 
Az Aspose nagyon [költséghatékony](https://purchase.aspose.com/) és jogdíj‑mentes újraelosztási licencet biztosít, amely korlátlan számú felhasználó számára engedélyezi a telepítést licencelési aggodalmak nélkül.
{{% /alert %}} 

Web‑alapú alkalmazások fejlesztésekor fontos megjegyezni, hogy a Microsoft Office automatizációs komponensek sem árazottak, sem szerveroldali megoldásokra licencelték. Ennek következtében nincs megfelelő licencelési megoldás a Microsoft Office‑t használó webalkalmazások telepítésére. Az Aspose ezzel szemben nagyon [költséghatékony](https://purchase.aspose.com/) megoldást kínál szerver‑oldali alkalmazásokhoz is.

## **Funkciók**
Az Aspose komponensek mindent biztosítanak az Office fájlok kezeléséhez és még sok mást. Ezt a filozófiánk alapján terveztük, miszerint segíteni akarjuk a fejlesztőket abban, hogy a lehető legkevesebb erőfeszítéssel érjék el a legnagyobb eredményeket.

{{% alert color="primary" %}} 
Az Office automatizációval szemben az Aspose komponensek számos erőteljes és időt takarító funkciót kínálnak.
{{% /alert %}} 

Például a [Aspose.Cells](https://products.aspose.com/cells/net/) lehetővé teszi a fejlesztők számára, hogy egy **DataTable** vagy **DataView**‑ból közvetlenül importáljanak adatokat egy Excel fájlba. Az [Aspose.Words](https://products.aspose.com/words/net/) hasonló funkciót biztosít, amely lehetővé teszi a fejlesztőknek, hogy egy Word (azaz Mail Merge) dokumentumot közvetlenül bármely .NET adatobjektumból töltsenek fel. [Minden komponens](https://products.aspose.com/total/net/) az Aspose családban saját egyedi és erőteljes funkciókészlettel rendelkezik.

Az Aspose komponens megvásárlásának legjobb része, hogy hozzáférést kap a fejlesztői csapatainkhoz. Például, ha Office automatizációs objektumokat használ, és bizonyos funkciókra van szüksége, azok hozzáadásának esélye nagyon, nagyon alacsony. Azonban az Aspose komponensekkel ez más.

{{% alert color="primary" %}} 
Fejlesztői csapatunk megérti, hogy ha egy adott funkcióra a vállalata számára szükség van, jó eséllyel más cégeknek is szükségük van ugyanarra a funkcióra. Bár tudjuk, hogy nem tudunk minden kért funkciót megvalósítani, igyekszünk a lehető legtöbb funkciót hozzáadni ügyfeleink visszajelzései alapján.
{{% /alert %}} 

Csapataink mindig nyitottak és rugalmasak a támogatás nyújtásában – és ez az oka annak, hogy az Aspose komponensek ilyen erőteljesek lettek.

## **Következtetés**
{{% alert color="primary" %}} 
Miközben ez a cikk néhány kulcsfontosságú pontot tárgyalt, amiért az Aspose komponensek jobb választásnak számítanak az Office automatizációval szemben, meg kell érteni, hogy sok-sok további előny is létezik. Csak néhány fő előnyt ismertettünk. 

Ezen felül minden Aspose termék és komponens kockázat‑mentes, kötelezettség‑mentes [Értékelő Verziót](https://downloads.aspose.com/slides/hu/net) kínál. Buzdítjuk, hogy használja ki az értékelést, és lássa, mit tehet az Aspose az alkalmazásaival vagy vállalkozásával.
{{% /alert %}}