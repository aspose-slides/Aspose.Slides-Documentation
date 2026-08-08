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
- bemutató
- C++
- Aspose.Slides
description: "Fedezze fel, miért kockázatos a Office automatizálás szervereken és szolgáltatásokban, és hogyan kínálja az Aspose.Slides a PowerPoint és OpenDocument biztonságosabb, gyorsabb bemutatófeldolgozását."
---
## **Bevezetés**

Számos ok miatt az Aspose komponensek jobb alternatívát jelentenek az automatizáláshoz. A főbb okok a következők:

- Biztonság
- Stabilitás
- Skálázhatóság/Sebesség
- Ár
- Funkciók

Az alábbiakban részletesebb magyarázatot talál mindegyik kulcsponthoz.

## **Fontos kérdések**
- Miért jóval jobb lehetőség az Aspose komponensek, mint a Microsoft Office automatizálás?

Két kérdést hallunk leggyakrabban itt az Aspose-nál :

- Megköveteli a termékeik, hogy a Microsoft Office telepítve legyen a futtatáshoz?

A rövid egyszerű válasz **NEM**. Az Aspose és az Aspose komponensek teljesen függetlenek, és nem állnak kapcsolatban a Microsoft Corporation-nal, sem engedélyezettek, támogatottak vagy egyéb módon jóváhagyottak.

- Miért kellene az Aspose termékeket használnunk a Microsoft Office automatizálás helyett?

A legrövidebb válasz, amit adhatunk, hogy sok oka van, a legfontosabb, hogy a *Microsoft maga erősen ajánlja a Office automatizálás mellőzését a szoftveres megoldásoktól: [Microsoft Article

## **Biztonság**
A következő idézet közvetlenül a fenti hivatkozott Microsoft Article ből származik:
*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

Az Aspose termékek nagyon biztonságosak. Ezért az Aspose komponensek nem jelentenek potenciális kockázatot a létfontosságú rendszererőforrások számára. Továbbá, amikor egy dokumentumot egy Aspose komponens nyit meg, a makrók nem indulnak el automatikusan. Az Aspose komponenseket úgy tervezték, hogy a fejlesztők Office fájlokat hozhassanak létre, módosíthassanak és menthessenek. A Microsoft Office csomaggal kapcsolatos kockázatok nem jelennek meg az Aspose komponensekben.

## **Stabilitás**
A következő idézet közvetlenül a fenti hivatkozott Microsoft Article ből származik:
*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

Mivel az Aspose komponensek egyetlen DLL-be vannak csomagolva, soha nem lesz szükség további részek vagy darabok telepítésére a működésükhöz. Az Aspose komponenseket kizárólag C++ alkalmazások használják, és nincs benne olyan kódrészlet, amely emberi válaszra várna. Az Aspose komponensek alapos tesztelésen estek át, és rendkívül stabilak. Az Aspose komponenseket használják [Companies](https://about.aspose.com/customers) közül például: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** és még sok más.

## **Skálázhatóság/Sebesség**
A következő idézet közvetlenül a fenti hivatkozott Microsoft Article ből származik:

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.*

Az Aspose komponensek rendkívül skálázhatóak és villámgyorsak. Az Office alkalmazásokat nem tervezték arra, hogy egyszerre 100‑as vagy 1000‑es felhasználók használják őket. Az Aspose komponensek ezzel szemben erre lettek építve. A komponenseink valódi C++ megoldások, amelyek hibátlanul működnek akár egyetlen szerveren, egyetlen alkalmazást kiszolgálva, akár egy terheléselosztó Web Formon, amely vállalati szintű alkalmazást támogat.

## **Ár**
Amikor egy alkalmazás a Microsoft Office automatizálást használja, minden gépre, amelyen az alkalmazás fut, meg kell vásárolni a Microsoft Office egy példányát. Sok esetben az alkalmazásnak csak fájlokat kell létrehoznia vagy módosítania, anélkül, hogy a felhasználónak szüksége lenne a Microsoft Office-ra. Az Aspose nagyon [Cost Effective](https://purchase.aspose.com/) és jogdíjmentes újraelosztási licencet kínál, amely lehetővé teszi a kiadást korlátlan számú felhasználó számára licencelési gondok nélkül. Webes alkalmazások fejlesztésekor fontos tudni, hogy a Microsoft Office Automatizálás komponensek nincsenek árazva és licencelve szerveroldali megoldásokra; ezért nincs megfelelő licencelési megoldás webalkalmazások kiadására, amelyek Microsoft Office komponenseket használnak. Az Aspose nagyon [Cost Effective](https://purchase.aspose.com/) megoldást biztosít szerveroldali alkalmazásokhoz is.

## **Funkciók**
Az Aspose komponensek mindent biztosítanak az Office fájlok kezeléséhez, és még sok mást is. Olyan filozófiával lettek megtervezve, amely lehetővé teszi a fejlesztők számára, hogy a legjobb eredményeket a legkevesebb munkával érjék el. Az Office Automatizálással szemben az Aspose komponensek számos erőteljes és időt takarító funkciót kínálnak. Például a [Aspose.Cells](https://products.aspose.com/cells/cpp/) lehetővé teszi a fejlesztőknek, hogy adatokat importáljanak egy **DataTable**‑ból vagy **DataView**‑ból közvetlenül egy Excel fájlba. A [Aspose.Words](https://products.aspose.com/words/net/) hasonló funkciót kínál, amely lehetővé teszi a fejlesztőknek, hogy egy Word (Mail Merge) dokumentumot töltsenek fel közvetlenül bármely C++ adatobjektusból. A [Every Component](https://products.aspose.com/total/cpp/) az Aspose családból saját egyedi és erőteljes funkciókkal bír. A legjobb része egy Aspose komponens megvásárlásának, hogy hozzáférhetünk a fejlesztői csapatainkhoz. Fejlesztői csapataink felismerik, hogy ha egy funkcióra van szüksége a vállalatának, valószínűleg más cégeknél is szükség lesz rá. Bár nem minden funkciókérés valósítható meg, csapataink nagyon nyitottak és rugalmasak a segítségnyújtásban. Ez a gondolkodásmód tette az Aspose komponenseket olyan erőssé, amilyenek ma. Ha további funkciókat szeretne az Office Automatizálás objektumaiból, esélye, hogy ezeket hozzáadják, nagyon, nagyon alacsony.

## **Összegzés**
{{% alert color="primary" %}} 

Miközben ez a cikk számos kulcspontot lefed, amelyek miatt az Aspose komponensek jobb választásnak bizonyulnak az Office Automatizáláshoz képest, rengeteg más előny is létezik. Ez a cikk elsősorban a legfontosabb pontokra koncentrál. Minden különböző Aspose komponens kockázatmentes, kötelezettség nélküli [Evaluation Version](https://downloads.aspose.com/slides/hu/cpp)‑t kínál. Javasoljuk, hogy használja ki ezt a [Evaluation](https://downloads.aspose.com/slides/hu/cpp)‑t, hogy jobban lássa, mit tud nyújtani az Aspose az Ön alkalmazásai számára.
{{% /alert %}}