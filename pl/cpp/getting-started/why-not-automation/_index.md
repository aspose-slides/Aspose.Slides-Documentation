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
- Dlaczego komponenty Aspose są znacznie lepszą opcją niż Microsoft Office Automation?

Są dwa pytania, które najczęściej słyszymy tutaj w Aspose :

- Czy twoje produkty wymagają zainstalowanego Microsoft Office, aby mogły działać?

Krótka i prosta odpowiedź to **NIE**. Aspose i komponenty Aspose są całkowicie niezależne i nie są powiązane, ani autoryzowane, sponsorowane ani w żaden sposób zatwierdzone przez Microsoft Corporation.

- Dlaczego powinniśmy używać produktów Aspose zamiast wykorzystywać Microsoft Office Automation?

Najkrótsza odpowiedź, jaką możemy podać, to że istnieje wiele powodów, przy czym najważniejszy jest fakt, że *Microsoft sam zdecydowanie odradza automatyzację Office w rozwiązaniach programowych: [Microsoft Article

## **Bezpieczeństwo**
Poniżej znajduje się bezpośredni cytat z wyżej wymienionego artykułu Microsoft:

*"Aplikacje Office nigdy nie były przeznaczone do użycia po stronie serwera i dlatego nie uwzględniają problemów bezpieczeństwa, z jakimi spotykają się komponenty rozproszone. Office nie uwierzytelnia przychodzących żądań i nie chroni przed nieumyślnym uruchamianiem makr lub uruchamianiem innego serwera, który może uruchamiać makra, z kodu po stronie serwera. Nie otwieraj plików przesłanych na serwer przez anonimowy Web! W zależności od ostatnio ustawionych ustawień bezpieczeństwa serwer może uruchamiać makra w kontekście Administratora lub Systemu z pełnymi uprawnieniami i zagrażać twojej sieci! Dodatkowo Office używa wielu komponentów po stronie klienta (takich jak Simple MAPI, WinInet, MSDAIPP), które mogą buforować informacje uwierzytelniające klienta w celu przyspieszenia przetwarzania. Jeśli Office jest automatyzowany po stronie serwera, jedna instancja może obsługiwać więcej niż jednego klienta i ponieważ informacje uwierzytelniające zostały zbuforowane dla tej sesji, możliwe jest, że jeden klient może używać zbuforowanych poświadczeń innego klienta, uzyskując w ten sposób nieprzyznane uprawnienia dostępu poprzez podszywanie się pod innych użytkowników."*

Produkty Aspose są bardzo bezpieczne. Dlatego komponenty Aspose nie stanowią potencjalnego ryzyka dla kluczowych zasobów systemu. Ponadto, gdy dokument zostaje otwarty przez komponent Aspose, makra nie są uruchamiane automatycznie. Komponenty Aspose zostały stworzone z myślą o umożliwieniu programistom tworzenia, modyfikowania i zapisywania plików Office. Żadne z ryzyk związanych z pakietem Microsoft Office nie są wrodzone komponentom Aspose.

## **Stabilność**
Poniżej znajduje się bezpośredni cytat z wyżej wymienionego artykułu Microsoft:

*"Office 2000, Office XP i Office 2003 używają technologii Microsoft Windows Installer (MSI), aby ułatwić instalację i samonaprawę użytkownikowi końcowemu. MSI wprowadza koncepcję „instalacji przy pierwszym użyciu”, co pozwala dynamicznie instalować lub konfigurować funkcje w czasie działania (dla systemu lub częściej dla konkretnego użytkownika). W środowisku po stronie serwera spowalnia to wydajność i zwiększa prawdopodobieństwo pojawienia się okna dialogowego, które prosi użytkownika o zatwierdzenie instalacji lub podanie odpowiedniego dysku instalacyjnego. Chociaż ma to na celu zwiększenie odporności Office jako produktu dla użytkownika końcowego, implementacja możliwości MSI w Office jest nieproduktywna w środowisku po stronie serwera. Ponadto stabilność Office ogólnie nie może być zapewniona przy uruchamianiu po stronie serwera, ponieważ nie został on zaprojektowany ani przetestowany pod kątem takiego użycia. Używanie Office jako komponentu usługowego na serwerze sieciowym może obniżyć stabilność tej maszyny, a w konsekwencji całej sieci. Jeśli planujesz automatyzować Office po stronie serwera, spróbuj odizolować program na dedykowanym komputerze, który nie może wpływać na krytyczne funkcje i który może być restartowany w razie potrzeby."*

Ponieważ komponenty Aspose są pakowane w pojedynczy plik DLL, nie będzie nigdy potrzeby instalowania dodatkowych części lub składników, aby działały. Komponenty Aspose są wykorzystywane wyłącznie przez aplikacje C++ i nie zawierają części kodu komponentu zaprojektowanej do oczekiwania na reakcję człowieka. Komponenty Aspose zostały dokładnie przetestowane i są niezwykle stabilne. Komponenty Aspose są używane przez [Companies](https://about.aspose.com/customers) takie jak: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** i wiele, wiele więcej.

## **Skalowalność/Szybkość**
Poniżej znajduje się bezpośredni cytat z wyżej wymienionego artykułu Microsoft:

*"Komponenty po stronie serwera muszą być wysoce reentrantne, wielowątkowe komponenty COM o minimalnym narzucie i wysokiej przepustowości dla wielu klientów. Aplikacje Office są pod każdym względem ich dokładnym przeciwieństwem. Są to nie-reentrantne serwery automatyzacji oparte na STA, zaprojektowane do dostarczania różnorodnych, ale zasobożernych funkcji dla pojedynczego klienta. Oferują niewielką skalowalność jako rozwiązanie po stronie serwera i mają stałe limity ważnych elementów, takich jak pamięć, które nie mogą być zmieniane poprzez konfigurację. Co ważniejsze, używają globalnych zasobów (takich jak pliki mapowane w pamięci, globalne dodatki lub szablony oraz współdzielone serwery automatyzacji), co może ograniczać liczbę jednocześnie uruchomionych instancji i prowadzić do warunków wyścigu, jeśli są konfigurowane w środowisku wieloklienckim. Programiści planujący uruchomienie więcej niż jednej instancji dowolnej aplikacji Office jednocześnie powinni rozważyć pulowanie lub serializację dostępu do aplikacji Office w celu uniknięcia potencjalnych zakleszczeń lub korupcji danych”.*

Komponenty Aspose są wysoce skalowalne i błyskawicznie szybkie. Aplikacje Office nie zostały zaprojektowane do jednoczesnego użycia przez setki i tysiące użytkowników. Jednak komponenty Aspose są właśnie do tego stworzone. Nasze komponenty są prawdziwym rozwiązaniem C++ i działają bezbłędnie zarówno na pojedynczym serwerze, obsługując jedną aplikację, jak i na zrównoważonym obciążeniowo formularzu internetowym obsługującym aplikację na skalę całego przedsiębiorstwa.

## **Cena**
Gdy aplikacja wykorzystuje Microsoft Office Automation, każda maszyna uruchamiająca aplikację musi posiadać zakupioną kopię Microsoft Office. Często zdarza się, że aplikacja musi tworzyć lub modyfikować plik Office, ale nie wymaga od użytkownika posiadania Microsoft Office. Aspose oferuje bardzo [Kosztowo efektywne](https://purchase.aspose.com/) i wolne od opłat licencyjnych rozwiązanie redystrybucyjne, które pozwala na wdrożenie na nieograniczoną liczbę użytkowników bez obaw o licencjonowanie. Tworząc aplikacje internetowe, ważne jest, aby wiedzieć, że komponenty Microsoft Office Automation nie są wyceniane ani licencjonowane do rozwiązań po stronie serwera; w związku z tym nie ma dobrej, licencyjnej opcji wdrażania aplikacji webowych wykorzystujących komponenty Microsoft Office. Aspose oferuje bardzo [Kosztowo efektywne](https://purchase.aspose.com/) rozwiązanie również dla aplikacji serwerowych.

## **Funkcje**
Komponenty Aspose zapewniają wszystko, co potrzebne do zarządzania plikami Office i jeszcze więcej. Zostały zaprojektowane według filozofii umożliwiającej programistom osiągnięcie maksymalnych rezultatów przy minimalnym nakładzie pracy. W przeciwieństwie do Office Automation, komponenty Aspose oferują wiele potężnych i oszczędzających czas funkcji. Na przykład, [Aspose.Cells](https://products.aspose.com/cells/cpp/) pozwala programistom importować dane z **DataTable** lub **DataView** bezpośrednio do pliku Excel. [Aspose.Words](https://products.aspose.com/words/net/) udostępnia podobną funkcję, umożliwiającą wypełnianie dokumentu Word (czyli scalania poczty) bezpośrednio z dowolnego obiektu danych C++. [Every Component](https://products.aspose.com/total/cpp/) w rodzinie Aspose oferuje własny zestaw unikalnych i potężnych funkcji. Najlepszą częścią zakupu komponentu Aspose jest dostęp do naszych zespołów deweloperskich. Nasze zespoły rozumieją, że jeśli istnieje funkcja, której potrzebuje twoja firma, prawdopodobnie będzie ona potrzebna także innym firmom. Choć nie każda prośba o funkcję może zostać spełniona, nasze zespoły starają się być bardzo otwarte i elastyczne przy udzielaniu pomocy. To podejście pomogło komponentom Aspose stać się tak potężnymi, jakimi są. Jeśli potrzebujesz dodatkowych funkcji z obiektów Office Automation, twoje szanse na ich dodanie są bardzo, bardzo niskie.

## **Wnioski**
{{% alert color="primary" %}} 

Chociaż ten artykuł omówił wiele kluczowych powodów, dla których komponenty Aspose są lepszym wyborem niż Office Automation, istnieje o wiele więcej. Ten artykuł koncentruje się głównie na najważniejszych punktach. Wszystkie różne komponenty Aspose oferują bezpłatną, bez zobowiązań [Wersję ewaluacyjną](https://downloads.aspose.com/slides/pl/cpp). Zachęcamy do skorzystania z tej [Ewaluacji](https://downloads.aspose.com/slides/pl/cpp), aby lepiej zobaczyć, co Aspose może zrobić dla twoich aplikacji.
{{% /alert %}}