---
title: Dlaczego nie automatyzacja
type: docs
weight: 170
url: /pl/java/why-not-automation/
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
- Java
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

Krótka, prosta odpowiedź to **NIE**.

Komponenty Aspose są całkowicie niezależne i nie są powiązane, autoryzowane, sponsorowane ani w żaden inny sposób zatwierdzone przez Microsoft Corporation.

- Dlaczego powinniśmy używać produktów Aspose zamiast automatyzacji Microsoft Office?

Po pierwsze, istnieje wiele [korzyści, które zyskujesz, używając Aspose.Slides](/slides/pl/java/product-overview/).

Po drugie, Microsoft sam silnie **odradza** używanie automatyzacji Office w rozwiązaniach programowych.

## **Bezpieczeństwo**
Poniżej znajduje się bezpośredni cytat z artykułu Microsoft:

*"Aplikacje Office nigdy nie były przeznaczone do użycia po stronie serwera, a więc nie uwzględniają problemów bezpieczeństwa, z którymi borykają się komponenty rozproszone. Office nie uwierzytelnia przychodzących żądań i nie chroni przed nieumyślnym uruchamianiem makr ani przed uruchamianiem innego serwera, który może uruchamiać makra, z kodu po stronie serwera. Nie otwieraj plików przesłanych na serwer z anonimowej sieci! W zależności od ostatnich ustawień bezpieczeństwa serwer może uruchamiać makra w kontekście Administratora lub Systemu z pełnymi uprawnieniami i zagrozić Twojej sieci! Dodatkowo Office używa wielu komponentów po stronie klienta (takich jak Simple MAPI, WinInet, MSDAIPP), które mogą buforować informacje uwierzytelniające klienta w celu przyspieszenia przetwarzania. Jeśli Office jest automatyzowany po stronie serwera, jedna instancja może obsługiwać więcej niż jednego klienta i ponieważ informacje uwierzytelniające zostały zbuforowane dla tej sesji, istnieje możliwość, że jeden klient może używać buforowanych danych uwierzytelniających innego klienta, uzyskując w ten sposób nieprzyznane uprawnienia dostępu poprzez podszywanie się pod innych użytkowników."*

Aspose produkty są bardzo bezpieczne. Komponenty Aspose nie stanowią potencjalnego ryzyka dla kluczowych zasobów systemu. Ponadto, gdy dokument jest otwierany przez komponent Aspose, makra nie są uruchamiane automatycznie. Komponenty Aspose zostały stworzone w celu umożliwienia programistom tworzenia, modyfikowania i zapisywania plików Office. Żadne z ryzyk związanych z pakietem Microsoft Office nie jest wrodzone komponentom Aspose.

## **Stabilność**
Poniżej znajduje się bezpośredni cytat z artykułu Microsoft:

*"Office 2000, Office XP i Office 2003 wykorzystują technologię Microsoft Windows Installer (MSI), aby ułatwić instalację i naprawę samodzielną dla użytkownika końcowego. MSI wprowadza koncepcję „instalacji przy pierwszym użyciu”, co pozwala dynamicznie instalować lub konfigurować funkcje w czasie działania (dla systemu lub częściej dla konkretnego użytkownika). W środowisku po stronie serwera spowalnia to wydajność i zwiększa prawdopodobieństwo wyświetlenia okna dialogowego, które prosi użytkownika o zatwierdzenie instalacji lub podanie odpowiedniego dysku instalacyjnego. Chociaż ma to na celu zwiększenie odporności Office jako produktu dla użytkownika końcowego, implementacja możliwości MSI w Office jest nieproduktywna w środowisku po stronie serwera. Ponadto stabilność Office ogólnie nie może być zapewniona przy uruchamianiu po stronie serwera, ponieważ nie została zaprojektowana ani przetestowana pod tym kątem. Używanie Office jako komponentu usługowego na serwerze sieciowym może zmniejszyć stabilność tej maszyny, a w konsekwencji całej sieci. Jeśli planujesz automatyzację Office po stronie serwera, postaraj się odizolować program na dedykowanym komputerze, który nie może wpływać na krytyczne funkcje i który można w razie potrzeby zrestartować."*

Komponenty Aspose zostały gruntownie przetestowane i są niezwykle stabilne. Komponenty Aspose są używane przez [firmy](https://about.aspose.com/customers/) takie jak **Bank of America** i wiele innych.

## **Skalowalność/Szybkość**
Poniżej znajduje się bezpośredni cytat z artykułu Microsoft:

*"Komponenty po stronie serwera muszą być wysoce reentrantne, wielowątkowe komponenty COM o minimalnym narzucie i wysokiej przepustowości dla wielu klientów. Aplikacje Office są pod każdym względem dokładnym przeciwieństwem. Są to serwery automatyzacji oparte na STA, nie‑reentrantne, zaprojektowane do zapewniania różnorodnej, ale zasobo‑intensywnej funkcjonalności dla jednego klienta. Oferują niewielką skalowalność jako rozwiązanie po stronie serwera i mają stałe limity ważnych elementów, takich jak pamięć, które nie mogą być zmienione poprzez konfigurację. Co ważniejsze, używają globalnych zasobów (takich jak pamięciowo mapowane pliki, globalne dodatki lub szablony oraz współdzielone serwery automatyzacji), co może ograniczać liczbę jednocześnie działających instancji i prowadzić do warunków wyścigu, jeśli są skonfigurowane w środowisku wieloklientowym. Programiści planujący uruchomienie więcej niż jednej instancji dowolnej aplikacji Office jednocześnie muszą rozważyć* ***Pooling*** *lub* ***Serializing Access*** *do aplikacji Office, aby uniknąć potencjalnych* ***Deadlocks*** *lub* ***Data Corruption*** *.*"

Komponenty Aspose są wysoce skalowalne i błyskawicznie szybkie. Aplikacje Office nie zostały zaprojektowane do jednoczesnego użycia przez setki i tysiące użytkowników. Jednak komponenty Aspose są właśnie do tego stworzone. Nasze komponenty działają bez zarzutu zarówno na pojedynczym serwerze, obsługując jedną aplikację, jak i w zrównoważonej farmie serwerów webowych obsługującej aplikację na skalę całego przedsiębiorstwa.

## **Cena**
Kiedy aplikacja wykorzystuje Microsoft Office Automation, kopia Microsoft Office musi być zakupiona dla każdego komputera, na którym aplikacja działa. Często zdarza się, że aplikacja musi tworzyć lub modyfikować plik Office, ale nie wymaga, aby użytkownik posiadał Microsoft Office. Aspose oferuje bardzo [opłacalną](https://purchase.aspose.com/) i wolną od opłat licencyjnych licencję na redystrybucję, która pozwala na wdrożenie do nieograniczonej liczby użytkowników bez obaw o licencjonowanie.

Tworząc aplikacje internetowe, ważne jest, aby wiedzieć, że komponenty Microsoft Office Automation nie są wyceniane ani licencjonowane dla rozwiązań po stronie serwera; w związku z tym nie ma dobrego rozwiązania licencyjnego dla wdrażania aplikacji webowych wykorzystujących komponenty Microsoft Office. Aspose oferuje również bardzo opłacalne rozwiązanie dla aplikacji serwerowych.

## **Funkcje**
Komponenty Aspose zapewniają wszystko, co potrzebne do zarządzania plikami Office oraz znacznie więcej. Są zaprojektowane według filozofii umożliwiającej programistom osiągnięcie jak najlepszych rezultatów przy minimalnym nakładzie pracy. W przeciwieństwie do Office Automation, komponenty Aspose oferują wiele potężnych i oszczędzających czas funkcji. Na przykład, [Aspose.Cells](https://products.aspose.com/cells/java/) daje programistom możliwość importu danych z **DataTable** lub **DataView** bezpośrednio do pliku Excel. [Aspose.Words](https://products.aspose.com/words/java/) oferuje podobną funkcję, która pozwala programistom wypełnić dokument Word (czyli Mail Merge). [Every Component](https://products.aspose.com/total/java/) w rodzinie Aspose oferuje własny zestaw unikalnych i potężnych funkcji.

Najlepszą częścią zakupu komponentu Aspose (lub zestawu komponentów, takiego jak [Aspose.Total](https://products.aspose.com/total/java/) ) jest dostęp do naszych zespołów deweloperskich. Nasze zespoły zdają sobie sprawę, że jeśli istnieje funkcja, której potrzebuje Twoja firma, prawdopodobnie potrzebują ją również inne firmy. Choć nie każda prośba o funkcję może zostać zrealizowana, nasze zespoły starają się być bardzo otwarte i elastyczne w udzielaniu wsparcia. To podejście pomogło komponentom Aspose stać się tak potężnymi, jakimi są. Jeśli potrzebujesz dodatkowych funkcji z obiektów Office Automation, Twoje szanse na ich dodanie są bardzo, bardzo niskie.

## **Podsumowanie**
{{% alert color="info" title="Note" %}}
Chociaż ten artykuł omawia wiele kluczowych powodów, dla których komponenty Aspose są lepszym wyborem niż Office Automation, istnieje jeszcze wiele, wiele innych. Ten artykuł koncentruje się głównie na najważniejszych punktach. Wszystkie różne komponenty Aspose oferują bezpłatną, bez zobowiązań [Wersję Ewaluacyjną](https://releases.aspose.com/slides/pl/java/). Zachęcamy do skorzystania z tej wersji ewaluacyjnej, aby lepiej zobaczyć, co Aspose może zrobić dla Twoich aplikacji.
{{% /alert %}}