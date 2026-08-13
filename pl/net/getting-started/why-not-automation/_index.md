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
description: "Odkryj, dlaczego automatyzacja Office jest ryzykowna dla serwerów i usług oraz zobacz, jak Aspose.Slides zapewnia bezpieczniejsze i szybsze przetwarzanie prezentacji dla PowerPoint i OpenDocument."
---
## **Wprowadzenie**

Istnieje kilka powodów, dla których komponenty Aspose są lepszą alternatywą dla automatyzacji. Niektóre z kluczowych powodów to:

- Bezpieczeństwo
- Stabilność
- Skalowalność/Szybkość
- Cena
- Funkcje

Poniżej znajduje się bardziej szczegółowe wyjaśnienie każdego kluczowego punktu.

## **Ważne pytania**

Są dwa pytania, które często słyszymy w Aspose:

- Czy Wasze produkty wymagają zainstalowanego Microsoft Office, aby działać?

Krótka, prosta odpowiedź brzmi **NIE**.

Komponenty Aspose są całkowicie niezależne i nie są powiązane, autoryzowane, sponsorowane ani w żaden sposób zatwierdzone przez Microsoft Corporation.

- Dlaczego powinniśmy używać produktów Aspose zamiast automatyzacji Microsoft Office?

Po pierwsze, istnieje wiele [korzyści, które zyskujesz, używając Aspose.Slides](/slides/pl/net/product-overview/).

Po drugie, Microsoft sam wyraźnie **odradza** używanie Office Automation w rozwiązaniach programowych.

## **Bezpieczeństwo**
Poniżej znajduje się dosłowny cytat z artykułu Microsoft: 

> "Aplikacje Office nigdy nie były przeznaczone do użytku po stronie serwera, dlatego nie uwzględniają problemów bezpieczeństwa, z jakimi borykają się komponenty rozproszone. Office nie uwierzytelnia przychodzących żądań i nie chroni przed niezamierzonym uruchamianiem makr ani przed uruchamianiem innego serwera, który mógłby uruchamiać makra, z kodu po stronie serwera. Nie otwieraj plików przesłanych na serwer z anonimowej witryny! W zależności od ostatnio ustawionych ustawień zabezpieczeń, serwer może uruchamiać makra w kontekście Administratora lub Systemu z pełnymi uprawnieniami i zagrozić Twojej sieci! Dodatkowo Office używa wielu komponentów po stronie klienta (takich jak Simple MAPI, WinInet, MSDAIPP), które mogą buforować informacje o uwierzytelnieniu klienta w celu przyspieszenia przetwarzania. Jeśli Office jest automatyzowany po stronie serwera, jedna instancja może obsługiwać więcej niż jednego klienta i ponieważ informacje o uwierzytelnieniu zostały zbuforowane dla tej sesji, możliwe jest, że jeden klient może użyć zbuforowanych danych uwierzytelniających innego klienta, uzyskując w ten sposób nieprzyznane uprawnienia poprzez podszywanie się pod innych użytkowników."

Produkty Aspose są bardzo **bezpieczne**. Komponenty Aspose działają w tym samym kontekście użytkownika co wszystkie aplikacje ASP.NET (pod użytkownikiem ASPNET). Dlatego komponenty Aspose **nie** stanowią zagrożenia bezpieczeństwa. Nie zużywają również krytycznych zasobów systemowych. Co więcej, kiedy komponent Aspose otwiera dokument, makra nie są uruchamiane automatycznie. Komponenty Aspose zostały stworzone, aby umożliwić programistom tworzenie, modyfikowanie i zapisywanie plików Office.

{{% alert color="info" %}} 

Żadne z ryzyk związanych z pakietem Microsoft Office nie mają zastosowania do komponentów Aspose.

{{% /alert %}} 

## **Stabilność**
Ten tekst jest dosłownym cytatem z wcześniej przytoczonego artykułu Microsoft: 

> "Office 2000, Office XP i Office 2003 wykorzystują technologię Microsoft Windows Installer (MSI), aby ułatwić instalację i samonaprawę użytkownikowi końcowemu. MSI wprowadza koncepcję „instalacji przy pierwszym użyciu”, co pozwala dynamicznie instalować lub konfigurować funkcje w czasie wykonywania (dla systemu, a częściej dla konkretnego użytkownika). W środowisku po stronie serwera spowalnia to wydajność i zwiększa prawdopodobieństwo pojawienia się okna dialogowego, które prosi użytkownika o zatwierdzenie instalacji lub podanie odpowiedniego dysku instalacyjnego. Chociaż ma to na celu zwiększenie odporności Office jako produktu użytkownika końcowego, implementacja możliwości MSI w Office jest przeciwskuteczna w środowisku po stronie serwera. Ponadto stabilność Office w ogóle nie może być zapewniona, gdy jest uruchamiany po stronie serwera, ponieważ nie został on zaprojektowany ani przetestowany do takiego użycia. Używanie Office jako komponentu usługowego na serwerze sieciowym może obniżyć stabilność tej maszyny, a w konsekwencji całej sieci. Jeśli planujesz automatyzować Office po stronie serwera, postaraj się odizolować program na dedykowany komputer, który nie może wpływać na krytyczne funkcje i który może być restartowany w razie potrzeby."

Ponieważ komponenty Aspose są pakowane w pojedynczy plik DLL, ich użytkownicy nigdy nie muszą instalować dodatkowych części, aby mogły działać. Komponenty Aspose są wykorzystywane wyłącznie przez aplikacje .NET i nie zawierają żadnej części kodu przeznaczonej do oczekiwania na reakcję człowieka.

{{% alert color="info" %}} 

Komponenty Aspose zostały gruntownie przetestowane i potwierdzone jako bardzo stabilne. Komponenty Aspose są używane przez [firmy](http://www.aspose.com/Corporate/Aspose/Customerlist.html) takie jak **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** i wiele innych wiodących organizacji w różnych branżach i dziedzinach.

{{% /alert %}} 

## **Skalowalność/Szybkość**
Poniżej znajduje się dosłowny cytat z artykułu Microsoft: 

> "Komponenty po stronie serwera muszą być wysoce reentrantne, wielowątkowe komponenty COM o minimalnym narzucie i wysokiej przepustowości dla wielu klientów. Aplikacje Office są pod każdym względem ich dokładnym przeciwieństwem. Są to serwery automatyzacji oparte na STA, nie‑reentrantne, przeznaczone do świadczenia różnorodnych, ale zasobo‑intensywnych funkcji dla jednego klienta. Oferują niewielką skalowalność jako rozwiązanie po stronie serwera i mają stałe limity ważnych elementów, takich jak pamięć, które nie mogą być zmieniane poprzez konfigurację. Co ważniejsze, używają zasobów globalnych (takich jak mapowane pliki pamięci, globalne dodatki lub szablony oraz współdzielone serwery automatyzacji), co może ograniczać liczbę jednocześnie działających instancji i prowadzić do warunków wyścigu, jeśli są konfigurowane w środowisku wielu klientów. Programiści planujący uruchomienie więcej niż jednej instancji dowolnej aplikacji Office jednocześnie muszą rozważyć pulowanie lub serializację dostępu do aplikacji Office, aby uniknąć potencjalnych zakleszczeń lub uszkodzenia danych."

Komponenty Aspose są niezwykle skalowalne i błyskawicznie szybkie. Aplikacje Office nie zostały zaprojektowane do jednoczesnego użycia przez setki czy tysiące użytkowników, ale komponenty Aspose są właśnie do tego stworzone. Nasze komponenty to prawdziwe rozwiązanie .NET.

{{% alert color="info" %}} 

Wydajność komponentów Aspose jest bezbłędna zarówno na pojedynczym serwerze (zasilającym jedną aplikację), jak i w środowisku równoważonego obciążenia (obsługującym aplikację na poziomie całego przedsiębiorstwa).

{{% /alert %}} 

## **Cena**
Gdy aplikacja korzysta z automatyzacji Microsoft Office, konieczny jest zakup kopii Microsoft Office na każdy komputer, na którym aplikacja jest uruchamiana. Istnieje wiele sytuacji, w których aplikacja musi tworzyć lub modyfikować plik Office, ale proces ten nie wymaga Microsoft Office.

{{% alert color="info" %}} 

Aspose oferuje bardzo [opłacalną](https://purchase.aspose.com/) i wolną od opłat licencyjnych licencję na redystrybucję, która umożliwia wdrożenie na nieograniczoną liczbę użytkowników bez problemów licencyjnych.

{{% /alert %}} 

Podczas tworzenia aplikacji internetowych ważne jest, aby pamiętać, że komponenty automatyzacji Microsoft Office nie są wycenione ani licencjonowane do rozwiązań po stronie serwera. W związku z tym nie ma dobrego rozwiązania licencyjnego dla wdrażania aplikacji internetowych wykorzystujących komponenty Microsoft Office. Aspose natomiast oferuje bardzo [opłacalne](https://purchase.aspose.com/) rozwiązanie także dla aplikacji opartych na serwerze.

## **Funkcje**
Komponenty Aspose zapewniają wszystko, co potrzebne do zarządzania plikami Office i jeszcze więcej. Zostały zaprojektowane w oparciu o naszą filozofię pomagania programistom w osiąganiu jak najlepszych rezultatów przy minimalnym nakładzie pracy.

{{% alert color="info" %}} 

W przeciwieństwie do automatyzacji Office, komponenty Aspose oferują wiele potężnych i oszczędzających czas funkcji.

{{% /alert %}} 

Na przykład, [Aspose.Cells](https://products.aspose.com/cells/net/) daje programistom możliwość importowania danych z **DataTable** lub **DataView** bezpośrednio do pliku Excel. [Aspose.Words](https://products.aspose.com/words/net/) zapewnia podobną funkcję, umożliwiając programistom wypełnianie dokumentu Word (czyli korespondencji seryjnej) bezpośrednio z dowolnego obiektu danych .NET. [Każdy komponent](https://products.aspose.com/total/net/) w rodzinie Aspose oferuje własny zestaw unikalnych i potężnych funkcji.

Najlepszą częścią zakupu komponentu Aspose jest dostęp do naszych zespołów deweloperskich. Na przykład, jeśli używasz obiektów automatyzacji Office i potrzebujesz określonych funkcji, szanse na ich dodanie są bardzo, bardzo niskie. Jednak w przypadku komponentów Aspose sytuacja jest inna.

{{% alert color="info" %}} 

Nasze zespoły deweloperskie rozumieją, że jeśli istnieje funkcja potrzebna Twojej firmie, istnieje duża szansa, że inne firmy także jej potrzebują. Choć wiemy, że nie możemy zaimplementować każdej zgłoszonej funkcji, dążymy do dodania tak wielu funkcji, jak to możliwe, opierając się na opiniach naszych klientów.

{{% /alert %}} 

Nasze zespoły są zawsze otwarte i elastyczne w udzielaniu pomocy — i to jest powód, dla którego komponenty Aspose stały się tak potężne, jak są dzisiaj.

## **Wnioski**
{{% alert color="info" %}} 

Choć ten artykuł omówił niektóre kluczowe powody, dla których komponenty Aspose są lepszym wyborem niż automatyzacja Office, musisz zrozumieć, że istnieje wiele, wiele więcej korzyści. Przedstawiliśmy jedynie niektóre z głównych zalet.

Co więcej, wszystkie produkty i komponenty Aspose oferują wolną od ryzyka, bez zobowiązań [Wersję ewaluacyjną](https://downloads.aspose.com/slides/pl/net). Zachęcamy do skorzystania z wersji ewaluacyjnej, aby zobaczyć, co Aspose może zrobić dla Twoich aplikacji lub biznesu.

{{% /alert %}}