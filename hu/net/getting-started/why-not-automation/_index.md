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
  - prezentáció
  - .NET
  - C#
  - Aspose.Slides
description: "Fedezze fel, miért kockázatos az Office automatizálás szerverek és szolgáltatások esetén, és lássa, hogyan biztosít az Aspose.Slides biztonságosabb és gyorsabb prezentációfeldolgozást a PowerPoint és az OpenDocument számára."
---
## **Bevezetés**

Számos ok van arra, hogy az Aspose komponensek jobb alternatívát jelentenek az automatizáláshoz. A legfontosabb okok a következők:

- Biztonság
- Stabilitás
- Méretezhetőség / Sebesség
- Ár
- Funkciók

Az alábbiakban részletesebben kifejtjük az egyes kulcspontokat.

## **Fontos kérdések**

Két kérdést hallunk gyakran az Aspose-nál:

- A termékeikhez szükséges a Microsoft Office telepítése a futtatáshoz?

A rövid, egyszerű válasz **NEM**.

Az Aspose komponensek teljesen függetlenek, és nem állnak kapcsolatban, nincsenek engedélyezve, szponzorálva vagy más módon jóváhagyva a Microsoft Corporation által.

- Miért használjunk Aspose termékeket a Microsoft Office Automatizálás helyett?

Először is számos [azok az előnyök, amelyeket az Aspose.Slides használatakor élvez](/slides/hu/net/product-overview/) áll rendelkezésre.

Másodszor a Microsoft maga erősen **tanácsolja** az Office Automatizálás elkerülését a szoftveres megoldásokból.

## **Biztonság**
A következő közvetlen idézet egy Microsoft cikkből:

> "Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."

Az Aspose termékek nagyon **biztonságosak**. Az Aspose komponensek ugyanabban a felhasználói kontextusban futnak, mint minden ASP.NET alkalmazás (az ASPNET felhasználó alatt). Ezért az Aspose komponensek **nem** jelentenek biztonsági kockázatot. Emellett nem fogyasztanak kritikus rendszer-erőforrásokat. Továbbá, amikor egy Aspose komponens megnyit egy dokumentumot, a makrók nem futnak automatikusan. Az Aspose komponenseket úgy tervezték, hogy a fejlesztők létrehozhassák, manipulálhassák és menthessék az Office fájlokat.

{{% alert color="info" %}} 

Az Office csomaghoz kapcsolódó kockázatok egyike sem vonatkozik az Aspose komponensekre.

{{% /alert %}} 

## **Stabilitás**
Ez a szöveg közvetlen idézet a korábban hivatkozott Microsoft cikkből:

> "Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."

Mivel az Aspose komponensek egyetlen DLL-be vannak csomagolva, a felhasználóknak soha nem kell további részeket vagy darabokat telepíteniük a működéshez. Az Aspose komponenseket csak .NET alkalmazások használják, és a komponenskódban nincs olyan rész, amely emberi válaszra várna.

{{% alert color="info" %}} 

Az Aspose komponenseket alaposan tesztelték, és nagyon stabilnak bizonyultak. Az Aspose komponenseket olyan [cégek] (http://www.aspose.com/Corporate/Aspose/Customerlist.html) használják, mint az **IBM**, **Hilton**, **Reader's Digest**, **Bank of America**, és számos más vezető szervezet különböző iparágakban és területeken.

{{% /alert %}} 

## **Méretezhetőség/Sebesség**
A következő közvetlen idézet egy Microsoft cikkből:

> "Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.

Az Aspose komponensek hihetetlenül méretezhetők és villámgyorsak. Az Office alkalmazásokat nem úgy tervezték, hogy egyszerre több száz vagy ezer felhasználó használja őket, míg az Aspose komponenseket kifejezetten erre a célra fejlesztették. Komponenseink valódi .NET megoldást nyújtanak.

{{% alert color="info" %}} 

Az Aspose komponensek teljesítménye hibátlan egyetlen szerveren (egy alkalmazás futtatása) vagy egy terheléselosztott webformon (vállalati szintű alkalmazás) is.

{{% /alert %}} 

## **Ár**
Amikor egy alkalmazás a Microsoft Office Automatizálást használja, minden géphez, amelyen az alkalmazás fut, meg kell vásárolni egy Microsoft Office példányt. Sok esetben egy alkalmazásnak számos alkalommal kell létrehoznia vagy módosítania egy Office fájlt, de a folyamat nem igényli a Microsoft Office-t.

{{% alert color="info" %}} 

Az Aspose egy nagyon [költséghatékony](https://purchase.aspose.com/) és royalty‑free újraelosztási licencet kínál, amely korlátlan számú felhasználóra engedélyezi a telepítést licencelési aggodalmak nélkül.

{{% /alert %}} 

Web‑alapú alkalmazások létrehozásakor fontos megjegyezni, hogy a Microsoft Office Automatizálás komponensek sem árazottak, sem szerver‑oldali megoldásokra licencelt termékek nincsenek. Így nincs megfelelő licencelési megoldás a web‑alkalmazások telepítéséhez, amelyek Microsoft Office komponenseket használnak. Ezzel szemben az Aspose egy nagyon [költséghatékony](https://purchase.aspose.com/) megoldást kínál a szerver‑oldali alkalmazások számára is.

## **Funkciók**
Az Aspose komponensek minden szükséges funkciót biztosítanak az Office fájlok kezeléséhez, s még sok mást is. Ezeket a fejlesztőknek a legnagyobb eredmények elérése érdekében, a legkevesebb erőfeszítéssel terveztük meg.

{{% alert color="info" %}} 

Az Office Automatizálással ellentétben az Aspose komponensek számos erőteljes és időmegtakarító funkciót kínálnak.

{{% /alert %}} 

Például az [Aspose.Cells](https://products.aspose.com/cells/net/) lehetővé teszi a fejlesztők számára, hogy egy **DataTable** vagy **DataView** adatot közvetlenül egy Excel fájlba importáljanak. Az [Aspose.Words](https://products.aspose.com/words/net/) hasonló képességet biztosít, mellyel egy Word (azaz Mail Merge) dokumentumot tölthetnek fel közvetlenül bármely .NET adatobjektusból. [Minden komponens](https://products.aspose.com/total/net/) az Aspose családban saját egyedi és erőteljes funkciókkal rendelkezik.

Az Aspose komponens vásárlásának legjobb része, hogy hozzáférést kap a fejlesztői csapatainkhoz. Például, ha Office Automatizálás objektumokat használsz és bizonyos funkciókra van szükséged, annak esélye, hogy ezeket a funkciókat hozzáadják, nagyon, nagyon alacsony. Azonban az Aspose komponensekkel ez más.

{{% alert color="info" %}} 

Fejlesztői csapataink megértik, hogy ha egy funkcióra a cégednek szüksége van, nagy valószínűséggel más vállalatoknak is. Bár nem tudunk minden kérést megvalósítani, a lehető legtöbb funkciót igyekszünk hozzáadni ügyfeleink visszajelzései alapján.

{{% /alert %}} 

Csapataink mindig nyitottak és rugalmasak a segítségnyújtásban – ez az oka annak, hogy az Aspose komponensek annyira erőteljessé váltak.

## **Összegzés**
{{% alert color="info" %}} 

Bár ez a cikk csak néhány kulcsfontosságú okot említ, amiért az Aspose komponensek jobb választásnak bizonyulnak az Office Automatizálással szemben, sokkal több előny is létezik. Itt csak a legfontosabb előnyöket soroltuk fel.

Ezen felül minden Aspose termék és komponens kockázatmentes, kötelezettségmentes [Értékelő verziót](https://downloads.aspose.com/slides/hu/net) kínál. Bátorítjuk, hogy használja ki az értékelést, és lássa, mit tehet a Aspose az alkalmazásaival vagy vállalkozásával.

{{% /alert %}}