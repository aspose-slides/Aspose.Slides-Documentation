---
title: Dlaczego nie automatyzacja
type: docs
weight: 170
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
description: "Odkryj, dlaczego automatyzacja Office jest ryzykowna dla serwerów i usług, oraz zobacz, jak Aspose.Slides zapewnia bezpieczniejsze i szybsze przetwarzanie prezentacji w PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Istnieje kilka powodów, dla których komponenty Aspose są lepszą alternatywą niż automatyzacja. Niektóre z kluczowych powodów to:

- Bezpieczeństwo
- Stabilność
- Skalowalność/Szybkość
- Cena
- Funkcje

Poniżej znajduje się bardziej szczegółowe wyjaśnienie każdego kluczowego punktu.

## **Ważne pytania**

Są dwa pytania, które często słyszymy w Aspose:

- Czy Wasze produkty wymagają zainstalowanego Microsoft Office, aby działały?

Krótką, prostą odpowiedzią jest **NIE**.

Komponenty Aspose są całkowicie niezależne i nie są powiązane, autoryzowane, sponsorowane ani w żaden sposób zatwierdzone przez Microsoft Corporation.

- Dlaczego powinniśmy używać produktów Aspose zamiast Microsoft Office Automation?

Po pierwsze, istnieje wiele [korzyści, które zyskujesz, używając Aspose.Slides](/slides/pl/net/product-overview/).

Po drugie, sam Microsoft zdecydowanie **odradza** używanie Office Automation w rozwiązaniach programowych.

## **Bezpieczeństwo**
The following is a direct quote from a Microsoft Article:

> "Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."

Produkty Aspose są bardzo **bezpieczne**. Komponenty Aspose działają w tym samym kontekście użytkownika co wszystkie aplikacje ASP.NET (pod użytkownikiem ASPNET). Dlatego komponenty Aspose **nie** stanowią ryzyka bezpieczeństwa. Nie zużywają też krytycznych zasobów systemowych. Co więcej, gdy komponent Aspose otwiera dokument, makra nie są uruchamiane automatycznie. Komponenty Aspose zostały stworzone, aby umożliwić programistom tworzenie, modyfikowanie i zapisywanie plików Office.

{{% alert color="info" title="Note" %}}
Żadne z ryzyk związanych z pakietem Microsoft Office nie mają zastosowania do komponentów Aspose.
{{% /alert %}}

## **Stabilność**
This text is a direct quote from the previously referenced Microsoft Article:

> "Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."

Ponieważ komponenty Aspose są pakowane w jednego pliku DLL, ich użytkownicy nigdy nie muszą instalować dodatkowych części czy elementów, aby działały. Komponenty Aspose są wykorzystywane wyłącznie przez aplikacje .NET i nie zawierają żadnego fragmentu kodu komponentu przeznaczonego do oczekiwania na reakcję człowieka.

{{% alert color="info" title="Note" %}}
Komponenty Aspose zostały gruntownie przetestowane i potwierdzone jako bardzo stabilne. Komponenty Aspose są używane przez [firmy](https://about.aspose.com/customers/) takie jak **Bank of America** i wiele innych wiodących organizacji w różnych branżach i dziedzinach.
{{% /alert %}}

## **Skalowalność/Szybkość**
The following is a direct quote from a Microsoft Article:

> "Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.

Komponenty Aspose są niezwykle skalowalne i błyskawicznie szybkie. Aplikacje Office nie zostały zaprojektowane do jednoczesnego użycia przez setki czy tysiące użytkowników, natomiast komponenty Aspose zostały stworzone właśnie do tego. Nasze komponenty są prawdziwym rozwiązaniem .NET.

{{% alert color="info" title="Note" %}}
Wydajność komponentów Aspose jest bezbłędna na pojedynczym serwerze (obsługującym jedną aplikację) lub w środowisku równoważenia obciążenia (obsługującym aplikację na poziomie całej firmy).
{{% /alert %}}

## **Cena**
When an application utilizes Microsoft Office Automation, a copy of Microsoft Office has to be purchased for every machine that runs the app. There are many instances an application may need to create or manipulate an office file, but the process does not require Microsoft Office.

{{% alert color="info" title="Note" %}}
Aspose oferuje bardzo [opłacalną](https://purchase.aspose.com/) i wolną od opłat licencyjnych licencję na redystrybucję, która umożliwia wdrożenie na nieograniczonej liczbie użytkowników bez obaw o licencjonowanie.
{{% /alert %}}

Tworząc aplikacje internetowe, ważne jest, aby pamiętać, że komponenty Microsoft Office Automation nie są wyceniane ani licencjonowane na rozwiązania po stronie serwera. Dlatego nie istnieje dobre rozwiązanie licencyjne dla wdrożeń aplikacji webowych wykorzystujących komponenty Microsoft Office. Aspose natomiast oferuje bardzo [opłacalne](https://purchase.aspose.com/) rozwiązanie dla aplikacji serwerowych.

## **Funkcje**
Komponenty Aspose zapewniają wszystko, co niezbędne do zarządzania plikami Office i wiele więcej. Zostały zaprojektowane zgodnie z naszą filozofią pomagania programistom w osiąganiu jak najlepszych rezultatów przy minimalnym nakładzie pracy.

{{% alert color="info" title="Note" %}}
W przeciwieństwie do Office Automation, komponenty Aspose oferują wiele potężnych i oszczędzających czas funkcji.
{{% /alert %}}

Na przykład, [Aspose.Cells](https://products.aspose.com/cells/net/) umożliwia programistom import danych z **DataTable** lub **DataView** bezpośrednio do pliku Excel. [Aspose.Words](https://products.aspose.com/words/net/) zapewnia podobną funkcję, pozwalającą programistom wypełnić dokument Word (czyli korespondencję seryjną) bezpośrednio z dowolnego obiektu danych .NET. [Every component](https://products.aspose.com/total/net/) w rodzinie Aspose oferuje własny zestaw unikalnych i potężnych funkcji.

Najlepszą częścią zakupu komponentu Aspose jest dostęp do naszych zespołów deweloperskich. Na przykład, jeśli korzystasz z obiektów Office Automation i potrzebujesz określonych funkcji, szanse, że te funkcje zostaną dodane, są bardzo, bardzo niskie. Jednak sytuacja jest inna w przypadku komponentów Aspose.

{{% alert color="info" title="Note" %}}
Nasze zespoły deweloperskie rozumieją, że jeśli Twoja firma potrzebuje określonej funkcji, istnieje duża szansa, że inne firmy potrzebują tej samej funkcji. Choć wiemy, że nie możemy zaimplementować każdej żądanej funkcji, staramy się dodać jak najwięcej funkcji na podstawie opinii naszych klientów.
{{% /alert %}}

Nasze zespoły są zawsze otwarte i elastyczne w udzielaniu pomocy — i to jest powód, dla którego komponenty Aspose stały się tak potężne, jak są teraz.

## **Podsumowanie**
{{% alert color="info" title="Note" %}}
Choć ten artykuł omówił niektóre kluczowe powody, dlaczego komponenty Aspose są lepszym wyborem niż Office Automation, musisz zrozumieć, że istnieje znacznie więcej korzyści. Przedstawiliśmy tylko część głównych zalet.

Co więcej, wszystkie produkty i komponenty Aspose oferują bezpłatną, bez zobowiązań [Wersję Ewaluacyjną](https://releases.aspose.com/slides/net/). Zachęcamy do skorzystania z wersji testowej, aby zobaczyć, co Aspose może zrobić dla Twoich aplikacji lub firmy.
{{% /alert %}}