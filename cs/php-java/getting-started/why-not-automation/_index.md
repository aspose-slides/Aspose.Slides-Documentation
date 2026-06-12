---
title: Proč ne automatizace
type: docs
weight: 50
url: /cs/php-java/why-not-automation/
keywords:
- automatizace
- Microsoft Office
- srovnání
- bezpečnost
- stabilita
- škálovatelnost
- funkce
- PowerPoint
- OpenDocument
- prezentace
- PHP
- Aspose.Slides
description: "Objevte, proč je automatizace Office riziková pro servery a služby, a zjistěte, jak Aspose.Slides nabízí bezpečnější a rychlejší zpracování prezentací pro PowerPoint a OpenDocument."
---
## **Přehled**

Existuje několik důvodů, proč jsou komponenty Aspose lepší alternativou k automatizaci. Některé z hlavních důvodů jsou:

- Bezpečnost
- Stabilita
- Škálovatelnost/Rychlost
- Cena
- Funkce

Níže je podrobnější vysvětlení každého hlavního bodu.

## **Důležité otázky**

Jsou to dvě otázky, které v Aspose často slyšíme:

- Vyžadují vaše produkty instalaci Microsoft Office, aby mohly běžet?

Krátká, jednoduchá odpověď je **NE**.

Komponenty Aspose jsou zcela nezávislé a nejsou spojeny, autorizovány, sponzorovány ani jinak schváleny společností Microsoft Corporation.

- Proč bychom měli používat produkty Aspose místo Microsoft Office Automation?

Nejprve existuje mnoho [výhod, které získáte při použití Aspose.Slides](/slides/cs/php-java/product-overview/).  
Druhé, samotná společnost Microsoft silně **nedoporučuje** používání Office Automation v softwarových řešeních.

## **Bezpečnost**

Následuje přímý citát z článku společnosti Microsoft: 

*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."* 

Aspose produkty jsou velmi bezpečné. Komponenty Aspose nepředstavují potenciální riziko pro důležité systémové zdroje. Navíc při otevření dokumentu komponentou Aspose se makra automaticky nespouštějí. Komponenty Aspose byly vytvořeny s cílem umožnit vývojářům vytvářet, upravovat a ukládat soubory Office. Žádná z rizik spojených s balíčkem Microsoft Office není vlastní komponentám Aspose.

## **Stabilita**

Následuje přímý citát z článku společnosti Microsoft: 

*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."* 

Komponenty Aspose byly důkladně testovány a jsou mimořádně stabilní. Komponenty Aspose používají [Společnosti](https://about.aspose.com/customers) jako: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** a mnoho dalších.

## **Škálovatelnost/Rychlost**

Následuje přímý citát z článku společnosti Microsoft: 

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more than one instance of any Office Application at the same time need to consider* ***Pooling*** *or* ***Serializing Access*** *to the Office Application for avoiding potential* ***Deadlocks*** *or* ***Data Corruption*** *.* 

Komponenty Aspose jsou vysoce škálovatelné a bleskově rychlé. Aplikace Office nebyly navrženy tak, aby je současně používalo stovky a tisíce uživatelů. Komponenty Aspose jsou však právě pro to určeny. Naše komponenty fungují bezchybně jak na jediném serveru, napájející jednu aplikaci, tak na vyváženém webovém formuláři napájejícím celopodnikovou aplikaci.

## **Cena**

Když aplikace využívá Microsoft Office Automation, je nutné zakoupit kopii Microsoft Office pro každý počítač, na kterém aplikace běží. Často se stává, že aplikace potřebuje vytvořit nebo upravit soubor Office, ale nevyžaduje, aby uživatel měl nainstalován Microsoft Office. Aspose nabízí velmi [nákladově efektivní](https://purchase.aspose.com/) a bezroyalty distribuční licence, která umožní nasazení na neomezený počet uživatelů bez starostí o licencování.

Při vytváření webových aplikací je důležité vědět, že komponenty Microsoft Office Automation nejsou cenově ani licenčně určeny pro serverová řešení; proto neexistuje vhodné licenční řešení pro nasazení webových aplikací využívajících komponenty Microsoft Office. Aspose také nabízí velmi nákladově efektivní řešení pro serverové aplikace.

## **Funkce**

Komponenty Aspose poskytují vše, co je potřeba pro správu souborů Office, a ještě mnohem více. Jsou navrženy s filozofií umožnit vývojářům dosáhnout největších výsledků s co nejmenším úsilím. Na rozdíl od Office Automation poskytují komponenty Aspose mnoho výkonných a čas šetřících funkcí. Například [Aspose.Cells](https://products.aspose.com/cells/php-java/) nabízí vývojářům možnost importovat data z **DataTable** nebo **DataView** přímo do souboru Excel. [Každá komponenta](https://products.aspose.com/total/php-java/) v rodině Aspose nabízí svůj vlastní soubor jedinečných a výkonných funkcí.

Nejlepším aspektem nákupu komponenty Aspose (nebo sad komponent, jako je [Aspose.Total](https://products.aspose.com/total/php-java/)) je přístup k našim vývojovým týmům. Naše vývojové týmy si uvědomují, že pokud vaše společnost potřebuje určitou funkci, pravděpodobně ji potřebují i další společnosti. I když ne každou žádost o funkci lze přidat, naše týmy se snaží být velmi otevřené a flexibilní při poskytování pomoci. Toto myšlení pomohlo komponentám Aspose stát se tak výkonnými, jaké jsou. Pokud potřebujete další funkce z objektů Office Automation, vaše šance, že budou přidány, jsou velmi, velmi nízké.

## **Závěr**
{{% alert color="primary" %}} 

Zatímco tento článek pokrývá mnoho hlavních důvodů, proč jsou komponenty Aspose lepší volbou než Office Automation, existuje ještě mnoho dalších. Tento článek se zaměřuje především na nejdůležitější body. Všechny různé komponenty Aspose nabízejí bezrizikovou, bez závazku [Evaluační verzi](https://downloads.aspose.com/slides/cs/java). Doporučujeme vám využít tuto evaluační verzi, abyste lépe viděli, co Aspose může pro vaše aplikace udělat. 

{{% /alert %}}