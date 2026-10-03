---
title: Miért ne használjunk automatizációt
type: docs
weight: 170
url: /hu/java/why-not-automation/
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
- Java
- Aspose.Slides
description: "Fedezze fel, miért kockázatos az Office automatizálása a szerverek és szolgáltatások számára, és lássa, hogyan nyújt az Aspose.Slides biztonságosabb és gyorsabb prezentációfeldolgozást a PowerPoint és az OpenDocument esetében."
---
## **Bevezetés**

Számos ok van arra, hogy az Aspose összetevők jobb alternatívát jelentenek az automatizáláshoz. Néhány kulcsfontosságú ok a következő:

- Biztonság
- Stabilitás
- Méretezhetőség/Sebesség
- Ár
- Funkciók

Alább részletesebb magyarázatot talál az egyes kulcsfontosságú pontokra.

## **Fontos kérdések**

Két kérdés van, amit gyakran hallunk az Aspose-nél:

- A termékeikhez szükséges a Microsoft Office telepítése a futtatáshoz?

A rövid, egyszerű válasz **NEM**.

- Miért kellene az Aspose termékeket használnunk a Microsoft Office Automation helyett?

Először is, számos [előny, amelyeket az Aspose.Slides használatakor élvez](/slides/hu/java/product-overview/).

Másodszor, a Microsoft maga erősen **nem javasolja** az Office Automation használatát szoftvermegoldásokból.

## **Biztonság**

Az alábbi közvetlen idézet egy Microsoft cikkből:

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*


Az Aspose termékek nagyon biztonságosak. Az Aspose összetevők nem jelentenek potenciális kockázatot a létfontosságú rendszer‑erőforrásokra. Továbbá, amikor egy dokumentumot egy Aspose összetevő nyit meg, a makrók nem futnak automatikusan. Az Aspose összetevőket úgy építették, hogy a fejlesztők létrehozhassák, módosíthassák és menthessék az Office fájlokat. A Microsoft Office csomaggal kapcsolatos kockázatok egyike sem áll fenn az Aspose összetevőkben.

## **Stabilitás**

Az alábbi közvetlen idézet egy Microsoft cikkből:

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*


Az Aspose összetevőket alaposan tesztelték és rendkívül stabilak. Az Aspose összetevőket olyan [cégek](https://about.aspose.com/customers/) használják, mint a **Bank of America** és még sok más.

## **Méretezhetőség/Sebesség**

Az alábbi közvetlen idézet egy Microsoft cikkből:

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more than one instance of any Office Application at the same time need to consider* ***Pooling*** *or* ***Serializing Access*** *to the Office Application for avoiding potential* ***Deadlocks*** *or* ***Data Corruption*** *.*


Az Aspose összetevők rendkívül méretezhetők és villámgyorsak. Az Office alkalmazásokat nem tervezték úgy, hogy egyszerre több száz vagy ezer felhasználó használja őket. Azonban az Aspose összetevők erre lettek tervezve. Az összetevőink hibátlanul működnek akár egyetlen szerveren, egyetlen alkalmazást meghajtva, akár egy terhelés‑elosztott webkiszolgáló farmon, amely vállalati szintű alkalmazást támogat.

## **Ár**

Amikor egy alkalmazás a Microsoft Office Automation-t használja, a Microsoft Office egy példányát minden gépre meg kell vásárolni, amelyen az alkalmazás fut. Sok esetben egy alkalmazásnak csak fájlt kell létrehoznia vagy módosítania, anélkül, hogy a felhasználónak a Microsoft Office-ra lenne szüksége. Az Aspose nagyon [Költséghatékony](https://purchase.aspose.com/) és royalty‑free újraelosztási licencet kínál, amely korlátlan számú felhasználó részére teszi lehetővé a telepítést licencelési aggodalmak nélkül.

Web‑alapú alkalmazások fejlesztésekor fontos tudni, hogy a Microsoft Office Automation összetevőket sem árazzák, sem licencelik szerveroldali megoldásokra; ezért nincs jó licencmegoldás a Microsoft Office komponenseket használó web‑alkalmazások telepítésére. Az Aspose nagyon Költséghatékony megoldást kínál szerver‑oldali alkalmazások számára is.

## **Funkciók**

Az Aspose összetevők mindent biztosítanak, ami az Office fájlok kezeléséhez szükséges, és még sok mást. Az a filozófia vezérli őket, hogy a fejlesztők a legkevesebb munkával érjék el a legnagyobb eredményt. Az Office Automation-től eltérően az Aspose összetevők számos erőteljes és időt takarító funkcióval rendelkeznek. Például az [Aspose.Cells](https://products.aspose.com/cells/java/) lehetővé teszi a fejlesztők számára, hogy egy **DataTable** vagy **DataView** adatait közvetlenül egy Excel‑fájlba importálják. Az [Aspose.Words](https://products.aspose.com/words/java/) hasonló funkciót kínál, mellyel a fejlesztők egy Word (Mail Merge) dokumentumot tölthetnek fel. [Every Component](https://products.aspose.com/total/java/) az Aspose családban saját egyedi és erőteljes funkciókészlettel rendelkezik.

Az Aspose komponens (vagy az [Aspose.Total](https://products.aspose.com/total/java/) komponenscsomag) megvásárlásának legjobb része a fejlesztői csapatokhoz való hozzáférés. Fejlesztői csapataink felismerik, hogy ha egy funkcióra a vállalatának szüksége van, valószínűleg más cégeknek is szükségük lesz rá. Bár nem minden funkciókérés kerül beépítésre, csapataink nagyon nyitottak és rugalmasak a segítségnyújtás során. Ez a szemlélet segítette, hogy az Aspose összetevők olyan erősek legyenek, mint amilyenek. Ha további Office Automation‑objektumokra vonatkozó funkciókra van szüksége, annak hozzáadása nagyon, nagyon valószínűtlen.

## **Következtetés**
{{% alert color="info" title="Note" %}}

Bár ez a cikk számos kulcsfontosságú okot lefed, amiért az Aspose összetevők jobb választásként vannak a Office Automation helyett, még sok-sok más is létezik. A cikk elsősorban csak a legfontosabb pontokat érinti. Minden különböző Aspose komponens kockázatmentes, kötelezettségmentes [Értékelő Verziót](https://releases.aspose.com/slides/hu/java/) kínál. Javasoljuk, hogy használja ki ezt az Értékelő Verziót, hogy jobban lássa, mit tehet az Aspose az Ön alkalmazásaival.

{{% /alert %}}