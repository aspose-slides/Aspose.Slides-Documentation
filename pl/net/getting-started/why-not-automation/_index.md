---
title: Dlaczego nie automatyzacja
type: docs
weight: 40
url: /pl/net/why-not-automation/
keywords:
- automatyzacja
- Microsoft Office
- porównanie
- bezpieczeństwo
- stabilność
- skalowalność
- funkcje
- PowerPoint
- OpenDocument
- prezentacja
- .NET
- C#
- Aspose.Slides
description: "Odkryj, dlaczego automatyzacja Office jest ryzykowna dla serwerów i usług, oraz zobacz, jak Aspose.Slides oferuje bezpieczniejsze i szybsze przetwarzanie prezentacji dla PowerPoint i OpenDocument."
---
## **Wprowadzenie**

There are several reasons Aspose components are a better alternative to automation. Some of the key reasons are:

- **Bezpieczeństwo**
- **Stabilność**
- **Skalowalność/Szybkość**
- **Cena**
- **Funkcje**

Below is a more detailed explanation of each key point.

## **Ważne pytania**

There are two questions we often hear at Aspose:

- **Czy Twoje produkty wymagają zainstalowanego Microsoft Office, aby działać?**

The short, simple answer is **NIE**.

Aspose components are completely independent and are not affiliated with, authorized by, sponsored by, or otherwise approved by Microsoft Corporation.

- **Dlaczego powinniśmy używać produktów Aspose zamiast automatyzacji Microsoft Office?**

First, there are many [korzyści, które zyskujesz, używając Aspose.Slides](/slides/pl/net/product-overview/).

Second, Microsoft itself strongly **odradza** using Office Automation from software solutions.

## **Bezpieczeństwo**
The following is a direct quote from a Microsoft Article: 

> "Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."

Aspose products are very **bezpieczne**. Aspose components run in the same user context as all ASP.NET applications (under the ASPNET user). Therefore, Aspose components do **not** pose a security risk. They also do not consume critical system resources. Furthermore, when an Aspose component opens a document, macros do not get to run automatically. Aspose components were built to allow developers to create, manipulate, and save Office files. 

{{% alert color="primary" %}} 
Żadne z ryzyk związanych z pakietem Microsoft Office nie mają zastosowania do komponentów Aspose.
{{% /alert %}} 

## **Stabilność**
This text is a direct quote from the previously referenced Microsoft Article: 

> "Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."

Since Aspose components are packaged into a single DLL, its users never need to install additional parts or pieces for them to function. Aspose components are only utilized by .NET applications and there is no portion of the component code designed to wait for a human response. 

{{% alert color="primary" %}} 
Komponenty Aspose zostały gruntownie przetestowane i potwierdzone jako bardzo stabilne. Komponenty Aspose są używane przez [firmy](http://www.aspose.com/Corporate/Aspose/Customerlist.html) takie jak **IBM**, **Hilton**, **Reader's Digest**, **Bank of America**, oraz wiele innych wiodących organizacji w różnych branżach i dziedzinach.
{{% /alert %}} 

## **Skalowalność/Szybkość**
The following is a direct quote from a Microsoft Article: 

> "Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.

Aspose components are incredibly scalable and lightning fast. Office applications were not designed to be simultaneously used by 100s or 1000s of users, but Aspose components are designed for that precisely. Our components are a true .NET solution. 

{{% alert color="primary" %}} 
Wydajność komponentów Aspose jest bezbłędna zarówno na pojedynczym serwerze (obsługującym jedną aplikację), jak i w środowisku równoważenia obciążenia (obsługującym aplikację na całym przedsiębiorstwie).
{{% /alert %}} 

## **Cena**
When an application utilizes Microsoft Office Automation, a copy of Microsoft Office has to be purchased for every machine that runs the app. There are many instances an application may need to create or manipulate an office file, but the process does not require Microsoft Office. 

{{% alert color="primary" %}} 
Aspose oferuje bardzo [opłacalną](https://purchase.aspose.com/) i wolną od tantiem licencję na redystrybucję, która pozwala na wdrożenie nieograniczonej liczby użytkowników bez obaw o licencjonowanie.
{{% /alert %}} 

When creating web-based applications, it is important to remember that Microsoft Office Automation components are neither priced nor licensed for server-side solutions. Therefore, there is no good licensing solution for the deployment of web applications that utilize Microsoft Office components. Aspose, on the other hand, provides a very [opłacalne](https://purchase.aspose.com/) solution for server-based applications as well.

## **Funkcje**
Aspose components provide everything needed for managing Office files and a lot more. We designed them based on our philosophy of helping developers to accomplish the greatest results possible with the least amount of effort. 

{{% alert color="primary" %}} 
W przeciwieństwie do automatyzacji Office, komponenty Aspose oferują wiele potężnych i oszczędzających czas funkcji. 
{{% /alert %}} 

For instance, [Aspose.Cells](https://products.aspose.com/cells/net/) gives developers the ability to import data from a **DataTable** or **DataView** directly into an Excel file. [Aspose.Words](https://products.aspose.com/words/net/) provides a similar feature that allows developers to populate a Word (that is, Mail Merge) document directly from any .NET data object. [Every component](https://products.aspose.com/total/net/) in the Aspose family offers their own set of unique and powerful features. 

The best part of purchasing an Aspose component is getting access to our development teams. For example, if you use Office Automation objects and need certain features, the chances of you getting those features to be added are very, very low. However, things are different with Aspose components. 

{{% alert color="primary" %}} 
Nasze zespoły deweloperskie rozumieją, że jeśli istnieje funkcja, której potrzebuje Twoja firma, istnieje duże prawdopodobieństwo, że potrzebują jej również inne firmy. Choć wiemy, że nie możemy wdrożyć każdej zgłoszonej funkcji, staramy się dodać jak najwięcej funkcji w oparciu o opinie naszych klientów. 
{{% /alert %}} 

Our teams are always open-minded and flexible when providing assistance—and this is the reason Aspose components have grown to become as powerful as they are now. 

## **Wnioski**
{{% alert color="primary" %}} 
Choć ten artykuł przedstawił niektóre kluczowe powody, dla których komponenty Aspose są lepszym wyborem niż automatyzacja Office, należy zrozumieć, że istnieje znacznie więcej korzyści. Przedstawiliśmy tylko niektóre z głównych zalet.

Co więcej, wszystkie produkty i komponenty Aspose oferują bezpieczną, bez zobowiązań [Wersję ewaluacyjną](https://downloads.aspose.com/slides/pl/net). Zachęcamy do skorzystania z wersji ewaluacyjnej, aby zobaczyć, co Aspose może zrobić dla Twoich aplikacji lub firmy. 
{{% /alert %}}