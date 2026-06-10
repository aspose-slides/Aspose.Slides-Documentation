---
title: Miért ne az automatizálás
type: docs
weight: 50
url: /hu/java/why-not-automation/
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
- Java
- Aspose.Slides
description: "Fedezze fel, miért kockázatos a Office automatizálás szerverek és szolgáltatások számára, és lássa, hogyan nyújt az Aspose.Slides biztonságosabb, gyorsabb prezentációfeldolgozást a PowerPoint és az OpenDocument esetében."
---
## **Bevezetés**

Számos oka van annak, hogy az Aspose komponensek jobb alternatívát jelentenek az automatizálásnak. A legfontosabb okok a következők:

- Biztonság
- Stabilitás
- Skálázhatóság/Sebesség
- Ár
- Funkciók

Az alábbiakban részletesebb magyarázatot talál minden kulcsponthoz.

## **Fontos kérdések**

Két kérdést hallunk gyakran az Aspose-nál:

- A termékeiknek szükséges a Microsoft Office telepítése a futtatáshoz?

A rövid, egyszerű válasz: **NEM**.

Az Aspose komponensek teljesen függetlenek, és nem állnak kapcsolatban, nincsenek engedélyezve, támogatva vagy egyéb módon jóváhagyva a Microsoft Corporation által.

- Miért használjunk Aspose termékeket a Microsoft Office Automatizálás helyett?

Először is számos [előnyt élvezhet, ha az Aspose.Slides‑t használ](/slides/hu/java/product-overview/).

Másodszor a Microsoft magától erősen **javasolja**, hogy kerüljük az Office Automatizálás használatát szoftveres megoldásokban.

## **Biztonság**

Az alábbi közvetlen idézet egy Microsoft‑cikkből:

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*


Az Aspose termékek nagyon biztonságosak. Az Aspose komponensek nem jelentenek potenciális kockázatot a létfontosságú rendszererőforrások számára. Továbbá, amikor egy dokumentumot egy Aspose komponens nyit meg, a makrók nem indulnak el automatikusan. Az Aspose komponenseket úgy tervezték, hogy a fejlesztők könnyedén létrehozhassanak, manipulálhassanak és menthessenek Office‑fájlokat. A Microsoft Office csomaggal kapcsolatos kockázatok egyike sem része az Aspose komponenseknek.

## **Stabilitás**
Az alábbi közvetlen idézet egy Microsoft‑cikkből:

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*


Az Aspose komponenseket alapos tesztelésnek vetették alá, és rendkívül stabilak. Az Aspose komponenseket olyan [cégek] (https://about.aspose.com/customers) használják, mint: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** és még sok más.

## **Skálázhatóság/Sebesség**
Az alábbi közvetlen idézet egy Microsoft‑cikkből:

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more than one instance of any Office Application at the same time need to consider* ***Pooling*** *or* ***Serializing Access*** *to the Office Application for avoiding potential* ***Deadlocks*** *or* ***Data Corruption*** *.* 


Az Aspose komponensek igen skálázhatóak és villámgyorsak. Az Office‑alkalmazásokat nem tervezték arra, hogy egyszerre több száz vagy ezer felhasználó használja őket. Az Aspose komponensek e célra lettek kifejlesztve. Komponenseink hibátlanul működnek akár egyetlen szerveren, amely egy alkalmazást támogat, akár egy terheléskiegyenlített webes űrlapon, amely egy vállalati szintű alkalmazást szolgál ki.

## **Ár**
Amikor egy alkalmazás a Microsoft Office Automatizálást használja, a Microsoft Office egy példányát minden olyan gépre meg kell vásárolni, amelyen az alkalmazás fut. Sok esetben az alkalmazásnak csak a fájl létrehozására vagy módosítására van szüksége, de a felhasználónak nem kell Microsoft Office‑nal rendelkeznie. Az Aspose nagyon [költséghatékony](https://purchase.aspose.com/) és jogdíjmentes újraelosztási licencet kínál, amely korlátlan számú felhasználó számára teszi lehetővé a telepítést licencelési aggályok nélkül.

Webalapú alkalmazások fejlesztésekor fontos tudni, hogy a Microsoft Office Automatizálás komponensei nincsenek szerveroldali megoldásokra árazva vagy licencelve; ezért nincs megfelelő licencelési megoldás webalkalmazások telepítéséhez, amelyek Microsoft Office komponenseket használnak. Az Aspose szintén nagyon költséghatékony megoldást kínál szerveroldali alkalmazásokhoz.

## **Funkciók**
Az Aspose komponensek mindent biztosítanak az Office‑fájlok kezeléséhez, sőt sokkal többet. Az a filozófia vezérli őket, hogy a fejlesztők a legkevesebb munkával érhessenek el a legnagyobb eredményeket. Az Office Automatizálással ellentétben az Aspose komponensek számos erőteljes és időt takarító funkciót nyújtanak. Például az [Aspose.Cells](https://products.aspose.com/cells/java/) lehetővé teszi a fejlesztők számára, hogy egy **DataTable**‑ből vagy **DataView**‑ból közvetlenül importáljanak adatokat egy Excel‑fájlba. Az [Aspose.Words](https://products.aspose.com/words/java/) hasonló funkciót kínál, amely lehetővé teszi a fejlesztőknek, hogy egy Word‑dokumentumot (Mail Merge) töltsenek fel. Az [Every Component](https://products.aspose.com/total/java/) az Aspose családban saját egyedi és erőteljes funkciókat kínál.

Az Aspose komponens (vagy például az [Aspose.Total](https://products.aspose.com/total/java/) komponenscsomag) megvásárlásának legjobb része, hogy hozzáférhet a fejlesztői csapatainkhoz. Fejlesztői csapataink tisztában vannak azzal, hogy ha egy funkcióra a cége szüksége van, akkor valószínűleg más cégeknek is szükségük lesz rá. Bár nem minden funkciókérés valósítható meg, csapataink nagyon nyitottak és rugalmasak a támogatás nyújtásában. Ez a szemlélet segítette, hogy az Aspose komponensek olyan erőteljesek legyenek, mint amilyenek. Ha további Office Automatizálás objektumokra vonatkozó funkciókra van szüksége, azok hozzáadásának esélye rendkívül alacsony.

## **Következtetés**
{{% alert color="primary" %}} 

Bár ez a cikk számos kulcsfontosságú okot tárgyal, amiért az Aspose komponensek jobb választásnak bizonyulnak az Office Automatizálás helyett, még ennél is több van. A cikk csak a legfontosabb pontokat érinti. Minden különálló Aspose komponens kockázatmentes, kötelezettség nélküli [Értékelő Verziót](https://downloads.aspose.com/slides/hu/java) kínál. Javasoljuk, hogy használja ki ezt az értékelést, hogy jobban lássa, mit tehet az Aspose az Ön alkalmazásaival. 

{{% /alert %}}