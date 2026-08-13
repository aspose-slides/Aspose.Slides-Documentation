---
title: Miért Nem Automatizáció
type: docs
weight: 50
url: /hu/java/why-not-automation/
keywords:
- automatizáció
- Microsoft Office
- összehasonlítás
- biztonság
- stabilitás
- skálázhatóság
- funkciók
- PowerPoint
- OpenDocument
- bemutató
- Java
- Aspose.Slides
description: "Fedezze fel, miért kockázatos az Office automatizáció szerverek és szolgáltatások esetén, és hogy az Aspose.Slides hogyan biztosít biztonságosabb, gyorsabb prezentációfeldolgozást a PowerPoint és az OpenDocument számára."
---
## **Bevezetés**

Számos oka van annak, hogy az Aspose komponensek jobb alternatívát jelentenek az automatizáláshoz. A legfontosabb okok a következők:

- Biztonság
- Stabilitás
- Skálázhatóság/Sebesség
- Ár
- Funkciók

Az alábbiakban részletesebb magyarázatot talál az egyes kulcspontokról.

## **Fontos kérdések**

Két kérdés hallatszik gyakran az Aspose-nál:

- A termékeikhez szükséges a Microsoft Office telepítése a futtatáshoz?

A rövid, egyszerű válasz **NEM**.

Az Aspose komponensek teljesen függetlenek, és nem állnak kapcsolatban, nem hitelesítették, nem szponzorálta vagy más módon jóváhagyta a Microsoft Corporation.

- Miért használjunk Aspose termékeket a Microsoft Office automatizálása helyett?

Először is számos [előnyt élvez, ha az Aspose.Slides‑ot használja](/slides/hu/java/product-overview/).

Másodszor a Microsoft maga erősen **javasolja a mellőzését** az Office Automation használatának szoftveres megoldásokból.

## **Biztonság**

Az alábbi közvetlen idézet egy Microsoft cikkből: 

*"Office alkalmazásokat sosem szánták szerveroldali használatra, ezért nem veszik figyelembe a disztribúciós komponenseket érintő biztonsági problémákat. Az Office nem hitelesíti a bejövő kéréseket, és nem védi meg a felhasználót attól, hogy véletlenül makrókat futtasson, vagy egy másik szervert indítson el, amely makrókat futtathat az Ön szerveroldali kódjából. Ne nyisson meg olyan fájlokat, amelyeket névtelen webről töltöttek fel a szerverre! A legutóbb beállított biztonsági beállítások alapján a szerver makrókat futtathat Administrator vagy System kontextusban teljes jogosultságokkal, ezzel veszélyeztetve a hálózatot! Ezen felül az Office számos kliensoldali összetevőt (például Simple MAPI, WinInet, MSDAIPP) használ, amelyek a kliens hitelesítési információit gyorsítás céljából cache‑lik. Ha az Office‑ot szerveroldalon automatizálják, egy példány több ügyfélt is kiszolgálhat, és mivel a hitelesítési információk a munkamenethez cache‑lve vannak, lehetséges, hogy egy ügyfél a másik ügyfél hitelesítő adatait használja, ezzel jogosulatlan hozzáférési jogosultságokat szerezve más felhasználók megszemélyesítésével."* 

Az Aspose termékek nagy biztonságot nyújtanak. Az Aspose komponensek nem jelentenek potenciális kockázatot a létfontosságú rendszer erőforrásokra. Ráadásul, amikor egy dokumentumot egy Aspose komponens nyit meg, a makrók nem futnak automatikusan. Az Aspose komponensek célja, hogy a fejlesztők Office fájlokat hozzanak létre, módosítsanak és mentenek. A Microsoft Office csomaggal kapcsolatos kockázatok nem vonatkoznak az Aspose komponensekre. 
## **Stabilitás**
Az alábbi közvetlen idézet egy Microsoft cikkből: 


*"Office 2000, Office XP és Office 2003 a Microsoft Windows Installer (MSI) technológiát használja a telepítés és az önjavítás egyszerűsítésére a végfelhasználó számára. Az MSI bevezeti a „telepítés első használatkor” koncepciót, amely lehetővé teszi a funkciók dinamikus telepítését vagy konfigurálását futásidőben (a rendszer vagy gyakrabban egy adott felhasználó számára). Egy szerveroldali környezetben ez lelassítja a teljesítményt és megnöveli annak valószínűségét, hogy megjelenik egy párbeszédablak, amely a felhasználótól engedélyt kér a telepítéshez vagy megfelelő telepítőlemezt kér. Bár az MSI képességek célja az Office végfelhasználói termékként való rugalmasságának növelése, az Office MSI megvalósítása hátrányos egy szerveroldali környezetben. Továbbá az Office általános stabilitása nem garantálható szerveroldali futtatás esetén, mivel nem tervezték vagy tesztelték erre a felhasználásra. Az Office hálózati szerveren szolgáltatáskomponensként való használata csökkentheti a gép stabilitását, és ezáltal az egész hálózatra is hatással lehet. Ha az Office‑ot szerveroldalon automatizálni kívánja, próbálja meg izolálni a programot egy dedikált számítógépre, amely nem befolyásolhat kritikus funkciókat, és szükség esetén újraindítható."* 


Az Aspose komponenseket alaposan tesztelték, és rendkívül stabilak. Az Aspose komponenseket [Vállalatok](https://about.aspose.com/customers) használják, például: **IBM** , **Hilton** , **Reader's Digest** , **Bank of America** és még sok más. 
## **Skálázhatóság/Sebesség**
Az alábbi közvetlen idézet egy Microsoft cikkből: 


*"Szerveroldali komponenseknek nagy reentranciával, többszálú COM komponensekkel kell rendelkezniük minimális terheléssel és nagy áteresztőképességgel több ügyfél számára. Az Office alkalmazások szinte minden tekintetben az ellenkezőjét jelentik. Nem reentránsak, STA‑alapú automatizálási szerverek, amelyeket úgy terveztek, hogy változatos, de erőforrás‑igényes funkciókat nyújtsanak egyetlen ügyfélnek. Kevés skálázhatóságot kínálnak szerveroldali megoldásként, és rögzített korlátokkal rendelkeznek fontos elemekre, például memóriára, amelyeket a konfiguráció nem módosíthat. Fontosabb, hogy globális erőforrásokat (például memória‑térképezett fájlok, globális kiegészítők vagy sablonok, valamint megosztott automatizálási szerverek) használnak, ami korlátozhatja az egyidejűleg futtatható példányok számát, és versenyhelyzetekhez vezethet, ha több ügyfél környezetben vannak beállítva. Azok a fejlesztők, akik egyszerre több példányt szeretnének futtatni bármely Office alkalmazásból, fontolják meg a **Pool‑olást** vagy a **Sorosítást** a Office alkalmazáshoz a lehetséges **Holtpontok** vagy **Adatsérülés** elkerülése érdekében.* 


Az Aspose komponensek rendkívül skálázhatóak és villámgyorsak. Az Office alkalmazásokat nem tervezték 100‑as vagy 1000‑es felhasználók egyidejű használatára. Azonban az Aspose komponenseket kifejezetten erre a célra tervezték. Komponenseink hibátlanul működnek akár egyetlen szerveren, egyetlen alkalmazást támogatva, akár egy terheléselosztott webes űrlapon, amely vállalati szintű alkalmazást hajt végre. 
## **Ár**
Amikor egy alkalmazás a Microsoft Office automatizálást használja, minden gépre, amelyen az alkalmazás fut, meg kell vásárolni egy Microsoft Office példányt. Sok esetben egy alkalmazásnak csak egy Office fájlt kell létrehoznia vagy módosítania, de a felhasználónak nem szükséges Microsoft Office‑t telepítenie. Az Aspose nagyon [Költséghatékony](https://purchase.aspose.com/) és jogdíjmentes terjesztési licencet kínál, amely lehetővé teszi a korlátlan felhasználószámú telepítést anélkül, hogy licencelési aggályok merülnének fel. 


Web‑alapú alkalmazások készítésekor fontos tudni, hogy a Microsoft Office Automation komponensek nem árazottak és nem licenceltek szerveroldali megoldásokra; ezért nincs megfelelő licencmegoldás webes alkalmazásokhoz, amelyek Microsoft Office komponenseket használnak. Az Aspose szintén egy nagyon Költséghatékony megoldást kínál szerver‑alapú alkalmazásokhoz is. 
## **Funkciók**
Az Aspose komponensek mindent biztosítanak az Office fájlok kezeléséhez, sőt még többet. Az a filozófia vezérli őket, hogy a fejlesztők a legkevesebb munkával érjék el a legjobb eredményeket. Az Office Automation ellentétben az Aspose komponensek számos hatékony és időt takarít meg funkciót kínálnak. Például a [Aspose.Cells](https://products.aspose.com/cells/java/) lehetővé teszi a fejlesztők számára, hogy adatokat importáljanak egy **DataTable**‑ből vagy **DataView**‑ból közvetlenül egy Excel fájlba. Az [Aspose.Words](https://products.aspose.com/words/java/) hasonló funkciót kínál, amellyel a fejlesztők egy Word (Mail Merge) dokumentumot tölthetnek fel. Minden komponens a [Aspose családban](https://products.aspose.com/total/java/) saját, egyedi és erőteljes funkciókészlettel rendelkezik. 


A legjobb dolog egy Aspose komponens (vagy az olyan komponenscsomagok, mint a [Aspose.Total](https://products.aspose.com/total/java/)) megvásárlásakor, hogy hozzáférhetünk fejlesztői csapatainkhoz. Fejlesztői csapataink felismerik, hogy ha egy funkcióra a vállalkozásuknak szüksége van, nagy valószínűséggel más vállalkozásoknak is szükségük lesz rá. Bár nem minden funkciókérés valósítható meg, csapataink nagyon nyitottak és rugalmasak a segítségnyújtás során. Ez a gondolkodásmód tette az Aspose komponenseket olyan erőssé, mint amilyenek. Ha további funkciókra van szüksége az Office Automation objektumokból, annak hozzáadása rendkívül alacsony eséllyel valósul meg. 
## **Összegzés**
{{% alert color="info" %}} 

Míg ez a cikk számos kulcspontot lefed, amelyek alapján az Aspose komponensek jobb választásnak bizonyulnak az Office Automation helyett, még sok-sok más ok is van. Ez a cikk elsősorban a legfontosabb pontokra fókuszál. Minden egyes Aspose komponens kockázatmentes, kötelezettség nélküli [Értékelő Verziót](https://downloads.aspose.com/slides/hu/java) kínál. Javasoljuk, hogy használja ki az Értékelő változatot, hogy jobban lássa, mit tehet az Aspose az Ön alkalmazásaival. 

{{% /alert %}}