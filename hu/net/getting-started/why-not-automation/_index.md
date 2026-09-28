---
title: Miért ne automatizálás
type: docs
weight: 170
url: /hu/net/why-not-automation/
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
- .NET
- C#
- Aspose.Slides
description: "Fedezze fel, miért kockázatos az Office automatizálás szerverek és szolgáltatások számára, és lássa, hogyan biztosítja az Aspose.Slides a biztonságosabb, gyorsabb prezentációfeldolgozást PowerPoint és OpenDocument esetén."
---
## **Bevezetés**

Számos oka van annak, hogy az Aspose összetevők jobb alternatívát jelentenek az automatizáláshoz. A legfontosabb okok a következők:

- Biztonság
- Stabilitás
- Skálázhatóság/Sebesség
- Ár
- Funkciók

Az alábbiakban részletesebb magyarázatot talál minden egyes kulcspontról.

## **Fontos kérdések**

Két gyakran hallott kérdés van az Aspose-nál:

- Megköveteli a termékeik futtatásához a Microsoft Office telepítését?

A rövid, egyszerű válasz **NEM**.

Az Aspose összetevők teljesen függetlenek, és nem állnak kapcsolatban, nem engedélyezettek, nem szponzoráltak, vagy egyéb módon nem jóváhagyottak a Microsoft Corporation által.

- Miért kellene az Aspose termékeket használnunk a Microsoft Office Automatizálás helyett?

  First, there are many [azok az előnyök, amelyeket az Aspose.Slides használata közben élvezhet](/slides/hu/net/product-overview/).

  Second, Microsoft magától is határozottan **ellenjavallja** az Office Automatizálás használatát szoftvermegoldásokból.

## **Biztonság**
Az alábbiak egy közvetlen idézet egy Microsoft cikkből:

> "Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."

Az Aspose termékek nagyon **biztonságosak**. Az Aspose összetevők ugyanabban a felhasználói kontextusban futnak, mint minden ASP.NET alkalmazás (az ASPNET felhasználó alatt). Ennek következtében az Aspose összetevők **nem** jelentenek biztonsági kockázatot. Emellett nem fogyasztanak kritikus rendszer-erőforrásokat. Továbbá, amikor egy Aspose összetevő megnyit egy dokumentumot, a makrók nem futnak automatikusan. Az Aspose összetevőket úgy tervezték, hogy a fejlesztők létrehozhassák, manipulálhassák és menthessék az Office fájlokat.

{{% alert color="info" title="Note" %}}
Az Aspose összetevőkre a Microsoft Office csomaghoz kapcsolódó kockázatok egyike sem vonatkozik.
{{% /alert %}}

## **Stabilitás**
Ez a szöveg egy közvetlen idézet a korábban hivatkozott Microsoft cikkből:

> "Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."

Mivel az Aspose összetevők egyetlen DLL-be vannak csomagolva, felhasználóiknak soha nem kell további részeket vagy alkatrészeket telepíteniük a működéshez. Az Aspose összetevőket csak .NET alkalmazások használják, és nincs a komponens kódban olyan rész, amely emberi válaszra várna.

{{% alert color="info" title="Note" %}}
Az Aspose összetevőket alaposan tesztelték, és megerősítették, hogy nagyon stabilak. Az Aspose összetevőket [vállalatok](https://about.aspose.com/customers/) használják, például a **Bank of America**, valamint számos más vezető szervezet különböző iparágakban és területeken.
{{% /alert %}}

## **Skálázhatóság/Sebesség**
Az alábbiak egy közvetlen idézet egy Microsoft cikkből:

> "Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.

Az Aspose összetevők hihetetlenül skálázhatóak és villámgyorsak. Az Office alkalmazásokat nem arra tervezték, hogy egyszerre több száz vagy ezer felhasználó használja őket, míg az Aspose összetevőket kifejezetten erre a célra fejlesztették. Az összetevőink valódi .NET megoldást jelentenek.

{{% alert color="info" title="Note" %}}
Az Aspose összetevők teljesítménye hibátlan egyetlen szerveren (egy alkalmazás működtetése) vagy egy terheléselosztott webes környezetben (vállalati szintű alkalmazás működtetése).
{{% /alert %}}

## **Ár**
Amikor egy alkalmazás a Microsoft Office Automatizálást használja, a Microsoft Office egy példányát meg kell vásárolni minden egyes gépre, amelyen az alkalmazás fut. Sok esetben egy alkalmazásnak szüksége lehet egy Office fájl létrehozására vagy manipulálására, de a folyamat nem igényli a Microsoft Office-t.

{{% alert color="info" title="Note" %}}
Az Aspose nagyon [költséghatékony](https://purchase.aspose.com/) és jogdíjmentes újraelosztási licencet biztosít, amely lehetővé teszi a korlátlan számú felhasználó telepítését licencelési aggályok nélkül.
{{% /alert %}}

Webes alkalmazások létrehozásakor fontos megjegyezni, hogy a Microsoft Office Automatizálási összetevők sem árazottak, sem licenceltek nem szerveroldali megoldásokra. Ennek következtében nincs megfelelő licencelési megoldás a Microsoft Office komponenseket használó webes alkalmazások telepítésére. Az Aspose ezzel szemben nagyon [költséghatékony](https://purchase.aspose.com/) megoldást kínál szerveroldali alkalmazásokhoz is.

## **Funkciók**
Az Aspose összetevők mindent biztosítanak az Office fájlok kezeléséhez, sőt még sok mást is. Azokat úgy terveztük, hogy segítsünk a fejlesztőknek a lehető legnagyobb eredmény elérésében a legkevesebb erőfeszítéssel.

{{% alert color="info" title="Note" %}}
Az Office Automatizálással szemben az Aspose összetevők számos erőteljes és időt takarító funkciót kínálnak.
{{% /alert %}}

Például a [Aspose.Cells](https://products.aspose.com/cells/net/) lehetővé teszi a fejlesztők számára, hogy adatokat importáljanak egy **DataTable** vagy **DataView** közvetlenül egy Excel fájlba. A [Aspose.Words](https://products.aspose.com/words/net/) hasonló funkciót kínál, amely a fejlesztőknek lehetővé teszi, hogy egy Word (azaz Mail Merge) dokumentumot töltsenek fel közvetlenül bármely .NET adatobjektumból. Az Aspose család minden [összetevője](https://products.aspose.com/total/net/) saját, egyedi és erőteljes funkciókészlettel rendelkezik.

Az Aspose összetevő megvásárlásának legjobb része, hogy hozzáférünk fejlesztői csapatainkhoz. Például, ha Office Automatizálási objektumokat használ, és bizonyos funkciókra van szüksége, annak esélye, hogy ezeket a funkciókat hozzáadják, nagyon, nagyon alacsony. Azonban az Aspose összetevőknél ez más.

{{% alert color="info" title="Note" %}}
Fejlesztői csapataink megértik, hogy ha egy olyan funkcióra van szüksége, amelyet az Ön cége igényel, nagy az esélye, hogy más vállalatok is ugyanazt a funkciót igénylik. Bár tudjuk, hogy nem tudunk minden kért funkciót megvalósítani, arra törekszünk, hogy a lehető legtöbb funkciót hozzáadjuk a vásárlóink visszajelzései alapján.
{{% /alert %}}

Csapataink mindig nyitottak és rugalmasak a segítségnyújtás során – ez az oka annak, hogy az Aspose összetevők olyan erőteljesek lettek, mint ma.

## **Következtetés**
{{% alert color="info" title="Note" %}}
Bár ez a cikk néhány kulcsfontosságú pontot érintett, amiért az Aspose összetevők jobb választásnak bizonyulnak az Office Automatizálás helyett, meg kell értenie, hogy sokkal több előny is van. Csak a főbb előnyök egy részét ismertettük.

Továbbá minden Aspose termék és összetevő kockázatmentes, kötelezettség nélküli [Értékelési verziót](https://releases.aspose.com/slides/hu/net/) kínál. Javasoljuk, hogy használja ki az értékelést, hogy lássa, mit tud nyújtani az Aspose az alkalmazásai vagy vállalkozása számára.
{{% /alert %}}