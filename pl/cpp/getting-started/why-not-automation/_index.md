---
title: Dlaczego nie automatyzacja
type: docs
weight: 50
url: /pl/cpp/why-not-automation/
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
- C++
- Aspose.Slides
description: "Odkryj, dlaczego automatyzacja Office jest ryzykowna dla serwerów i usług, oraz zobacz, jak Aspose.Slides oferuje bezpieczniejsze i szybsze przetwarzanie prezentacji dla PowerPoint i OpenDocument."
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
- Dlaczego komponenty Aspose są znacznie lepszą opcją niż Microsoft Office Automation?

Słyszymy najczęściej dwa pytania w Aspose:

- Czy Wasze produkty wymagają zainstalowanego Microsoft Office, aby mogły działać?

Krótka prosta odpowiedź to **NIE**. Aspose i komponenty Aspose są całkowicie niezależne i nie są powiązane, autoryzowane, sponsorowane ani w żaden sposób zatwierdzone przez Microsoft Corporation.

- Dlaczego powinniśmy używać produktów Aspose zamiast korzystać z Microsoft Office Automation?

Najkrótsza odpowiedź, jaką możemy podać, to że istnieje wiele powodów, a najważniejszy z nich jest to, że *Microsoft sam wyraźnie odradza automatyzację Office z rozwiązań programowych*: [Microsoft Article

## **Bezpieczeństwo**
Poniżej zamieszczono dosłowny cytat z wymienionego wyżej artykułu Microsoftu:
*"Office Applications were never intended for use server-side, and therefore do not take into consideration the security problems that are faced by distributed components. Office does not authenticate incoming requests, and does not protect you from unintentionally running macros, or starting another server that might run macros, from your server-side code. Do not open files that are uploaded to the server from an anonymous Web! Based on the security settings that were last set, the server can run macros under an Administrator or System context with full privileges and compromise your network! In addition, Office uses many client-side components (such as Simple MAPI, WinInet, MSDAIPP) that can cache client authentication information in order to speed up processing. If Office is being automated server-side, one instance may service more than one client, and because authentication information has been cached for that session, it is possible that one client can use the cached credentials of another client, and thereby gain non-granted access permissions by impersonating other users."*

Produkty Aspose są bardzo bezpieczne. Dlatego komponenty Aspose nie stanowią potencjalnego zagrożenia dla krytycznych zasobów systemu. Ponadto, gdy dokument jest otwierany przez komponent Aspose, makra nie są uruchamiane automatycznie. Komponenty Aspose zostały stworzone z myślą o umożliwieniu programistom tworzenia, modyfikacji i zapisywania plików Office. Żadne z ryzyk związanych z pakietem Microsoft Office nie jest wrodzone komponentom Aspose.

## **Stabilność**
Poniżej zamieszczono dosłowny cytat z wymienionego wyżej artykułu Microsoftu:
*"Office 2000, Office XP and Office 2003 use Microsoft Windows Installer (MSI) technology to make installation and self-repair easier for an end user. MSI introduces the concept of "install on first use", which allows features to be dynamically installed or configured at runtime (for the system, or more often for a particular user). In a server-side environment this both slows down performance and increases the likelihood that a dialog box may appear that asks for the user to approve the install or provide an appropriate install disk. Although it is designed to increase the resiliency of Office as an end-user product, Office's implementation of MSI capabilities is counterproductive in a server-side environment. Furthermore, the stability of Office in general cannot be assured when run server-side because it has not been designed or tested for this type of use. Using Office as a service component on a network server may reduce the stability of that machine and as a consequence your network as a whole. If you plan to automate Office server-side, attempt to isolate the program to a dedicated computer that cannot affect critical functions, and that can be restarted as needed."*

Ponieważ komponenty Aspose są spakowane w jednej bibliotece DLL, nigdy nie będzie potrzeby instalowania dodatkowych części, aby mogły działać. Komponenty Aspose są używane wyłącznie przez aplikacje C++ i nie zawierają żadnego fragmentu kodu oczekującego na reakcję człowieka. Komponenty Aspose zostały gruntownie przetestowane i są niezwykle stabilne. Komponenty Aspose są wykorzystywane przez [Companies](https://about.aspose.com/customers) takie jak: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** i wiele, wiele innych.

## **Skalowalność/Szybkość**
Poniżej zamieszczono dosłowny cytat z wymienionego wyżej artykułu Microsoftu:

*"Server-side components need to be highly reentrant, multi-threaded COM components with minimum overhead and high throughput for multiple clients. Office Applications are in almost all respects the exact opposite. They are non-reentrant, STA-based Automation servers that are designed to provide diverse but resource-intensive functionality for a single client. They offer little scalability as a server-side solution, and have fixed limits to important elements, such as memory, which cannot be changed through configuration. More importantly, they use global resources (such as memory mapped files, global add-ins or templates, and shared Automation servers), which can limit the number of instances that can run concurrently and lead to race conditions if they are configured in a multi-client environment. Developers who plan to run more then one instance of any Office Application at the same time need to consider Pooling or Serializing Access to the Office Application for avoiding potential Deadlocks or Data Corruption”.*

Komponenty Aspose są wysoce skalowalne i błyskawicznie szybkie. Aplikacje Office nie zostały zaprojektowane do jednoczesnego użycia przez setki czy tysiące użytkowników. Natomiast komponenty Aspose zostały stworzone właśnie z myślą o takim scenariuszu. Nasze komponenty to prawdziwe rozwiązanie C++ i działają bezbłędnie zarówno na pojedynczym serwerze obsługującym jedną aplikację, jak i w zrównoważonym środowisku Web Form obsługującym aplikację na skalę przedsiębiorstwa.

## **Cena**
Kiedy aplikacja korzysta z Microsoft Office Automation, każda maszyna uruchamiająca aplikację musi mieć zakupioną kopię Microsoft Office. Często zdarza się, że aplikacja musi utworzyć lub zmodyfikować plik Office, ale nie wymaga od użytkownika posiadania Microsoft Office. Aspose oferuje bardzo [Cost Effective](https://purchase.aspose.com/) i wolną od opłat licencyjnych licencję redystrybucji, która pozwala na wdrożenie nieograniczonej liczby użytkowników bez problemów licencyjnych. Tworząc aplikacje sieciowe, ważne jest, aby wiedzieć, że komponenty Microsoft Office Automation nie są wyceniane ani licencjonowane do rozwiązań po stronie serwera; w konsekwencji nie istnieje odpowiednie rozwiązanie licencyjne dla wdrażania aplikacji internetowych wykorzystujących te komponenty. Aspose oferuje bardzo [Cost Effective](https://purchase.aspose.com/) rozwiązanie także dla aplikacji serwerowych.

## **Funkcje**
Komponenty Aspose zapewniają wszystko, co potrzebne do zarządzania plikami Office, a nawet więcej. Zostały zaprojektowane z filozofią umożliwienia programistom osiągnięcia maksymalnych rezultatów przy minimalnym nakładzie pracy. W odróżnieniu od Office Automation, komponenty Aspose oferują wiele potężnych i oszczędzających czas funkcji. Na przykład, [Aspose.Cells](https://products.aspose.com/cells/cpp/) umożliwia programistom import danych z **DataTable** lub **DataView** bezpośrednio do pliku Excel. [Aspose.Words](https://products.aspose.com/words/net/) oferuje podobną funkcję, pozwalającą wypełnić dokument Word (Mail Merge) bezpośrednio z dowolnego obiektu danych C++. [Every Component](https://products.aspose.com/total/cpp/) w rodzinie Aspose oferuje własny zestaw unikalnych i potężnych funkcji. Najlepszą częścią zakupu komponentu Aspose jest dostęp do naszych zespołów deweloperskich. Nasze zespoły rozumieją, że jeśli dana funkcja jest potrzebna Twojej firmie, istnieje duże prawdopodobieństwo, że będzie potrzebna również innym firmom. Chociaż nie każda prośba o funkcję może zostać spełniona, nasze zespoły starają się być bardzo otwarte i elastyczne w udzielaniu wsparcia. To podejście pomogło komponentom Aspose stać się tak potężnymi, jakimi są. Jeśli potrzebujesz dodatkowych funkcji znanych z obiektów Office Automation, Twoje szanse na ich dodanie są bardzo, bardzo niskie.

## **Podsumowanie**
{{% alert color="primary" %}} 

Choć ten artykuł omawia wiele kluczowych powodów, dla których komponenty Aspose są lepszym wyborem niż Office Automation, istnieje jeszcze wiele, wiele innych. Artykuł ten koncentruje się głównie na najważniejszych punktach. Wszystkie różne komponenty Aspose oferują bezpłatną, bez zobowiązań [Evaluation Version](https://downloads.aspose.com/slides/pl/cpp). Zachęcamy do skorzystania z tej [Evaluation](https://downloads.aspose.com/slides/pl/cpp), aby lepiej przekonać się, co Aspose może zrobić dla Twoich aplikacji.