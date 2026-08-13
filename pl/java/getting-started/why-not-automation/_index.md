---
title: Dlaczego nie automatyzacja
type: docs
weight: 50
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

- Czy Wasze produkty wymagają zainstalowanego Microsoft Office, aby działały?

Krótka, prosta odpowiedź to **NIE**.

Komponenty Aspose są całkowicie niezależne i nie są powiązane, autoryzowane, sponsorowane ani w żaden inny sposób zatwierdzone przez Microsoft Corporation.

- Dlaczego powinniśmy używać produktów Aspose zamiast Microsoft Office Automation?

Po pierwsze, istnieje wiele [korzyści, które zyskujesz używając Aspose.Slides](/slides/pl/java/product-overview/).

Po drugie, sam Microsoft zdecydowanie **odradza** używanie Office Automation w rozwiązaniach programowych.

## **Bezpieczeństwo**

Poniżej znajduje się dosłowny cytat z artykułu Microsoft:

*"Aplikacje Office nigdy nie były przeznaczone do użytku po stronie serwera, dlatego nie uwzględniają problemów bezpieczeństwa, z jakimi borykają się komponenty rozproszone. Office nie uwierzytelnia przychodzących żądań i nie chroni przed przypadkowym uruchamianiem makr ani przed uruchamianiem innego serwera, który mógłby uruchamiać makra, z poziomu kodu po stronie serwera. Nie otwieraj plików przesłanych na serwer z anonimowej sieci! W zależności od ostatnio ustawionych ustawień bezpieczeństwa, serwer może uruchamiać makra w kontekście Administratora lub Systemu z pełnymi uprawnieniami, co może zagrozić Twojej sieci! Dodatkowo Office używa wielu komponentów po stronie klienta (takich jak Simple MAPI, WinInet, MSDAIPP), które mogą buforować informacje uwierzytelniające klienta w celu przyspieszenia przetwarzania. Jeśli Office jest automatyzowany po stronie serwera, jedna instancja może obsługiwać więcej niż jednego klienta i ponieważ informacje uwierzytelniające zostały zbuforowane dla tej sesji, możliwe jest, że jeden klient użyje zbuforowanych poświadczeń innego klienta, uzyskując w ten sposób nieprzyznane uprawnienia dostępu poprzez podszywanie się pod innych użytkowników."*

Produkty Aspose są bardzo bezpieczne. Komponenty Aspose nie stanowią potencjalnego ryzyka dla kluczowych zasobów systemowych. Co więcej, gdy dokument jest otwierany przez komponent Aspose, makra nie są uruchamiane automatycznie. Komponenty Aspose zostały stworzone z myślą o umożliwieniu programistom tworzenia, manipulowania i zapisywania plików Office. Żadne z ryzyk związanych z pakietem Microsoft Office nie jest wrodzone komponentom Aspose.

## **Stabilność**

Poniżej znajduje się dosłowny cytat z artykułu Microsoft:

*"Office 2000, Office XP i Office 2003 używają technologii Microsoft Windows Installer (MSI), aby ułatwić instalację i samonaprawę użytkownikowi końcowemu. MSI wprowadza koncepcję „instalacji przy pierwszym użyciu”, co pozwala dynamicznie instalować lub konfigurować funkcje w czasie działania (dla systemu lub częściej dla konkretnego użytkownika). W środowisku po stronie serwera spowalnia to zarówno wydajność, jak i zwiększa prawdopodobieństwo pojawienia się okna dialogowego, które prosi użytkownika o zatwierdzenie instalacji lub podanie odpowiedniego dysku instalacyjnego. Chociaż ma to na celu zwiększenie odporności Office jako produktu końcowego, implementacja możliwości MSI przez Office jest niekorzystna w środowisku po stronie serwera. Ponadto stabilność Office ogólnie nie może być zapewniona, gdy jest uruchamiany po stronie serwera, ponieważ nie został on zaprojektowany ani przetestowany do takiego użycia. Używanie Office jako komponentu usługi na serwerze sieciowym może obniżyć stabilność tej maszyny, a w konsekwencji całej sieci. Jeśli planujesz automatyzować Office po stronie serwera, postaraj się odizolować program na dedykowanym komputerze, który nie może wpływać na krytyczne funkcje i który można w razie potrzeby ponownie uruchomić."*

Komponenty Aspose zostały gruntownie przetestowane i są niezwykle stabilne. Komponenty Aspose są używane przez [firmy](https://about.aspose.com/customers) takie jak: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** i wiele, wiele innych.

## **Skalowalność/Szybkość**

Poniżej znajduje się dosłowny cytat z artykułu Microsoft:

*"Komponenty po stronie serwera muszą być wysoce reentrantne, wielowątkowe komponenty COM o minimalnym narzucie i wysokiej przepustowości dla wielu klientów. Aplikacje Office są pod prawie każdym względem ich dokładnym przeciwieństwem. Są to nie-reentrantne serwery Automacji oparte na STA, zaprojektowane do świadczenia różnorodnych, ale zasobochłonnych funkcji dla jednego klienta. Oferują niewielką skalowalność jako rozwiązanie po stronie serwera i mają stałe limity ważnych elementów, takich jak pamięć, które nie mogą być zmieniane poprzez konfigurację. Co ważniejsze, używają globalnych zasobów (takich jak pliki mapowane w pamięci, globalne dodatki lub szablony oraz współdzielone serwery Automacji), co może ograniczyć liczbę instancji mogących działać jednocześnie i prowadzić do warunków wyścigu, jeśli są skonfigurowane w środowisku wieloklienckim. Programiści planujący uruchomić więcej niż jedną instancję dowolnej aplikacji Office jednocześnie muszą rozważyć * ***Pooling*** *lub* ***Serializing Access*** *do aplikacji Office, aby uniknąć potencjalnych* ***Deadlocks*** *lub* ***Data Corruption*** *.*"

Komponenty Aspose są wysoce skalowalne i błyskawicznie szybkie. Aplikacje Office nie zostały zaprojektowane do jednoczesnego używania przez setki czy tysiące użytkowników. Jednak komponenty Aspose są właśnie do tego stworzone. Nasze komponenty działają bezbłędnie zarówno na pojedynczym serwerze, obsługując jedną aplikację, jak i w zrównoważonym obciążeniowo formularzu internetowym obsługującym aplikację na poziomie całego przedsiębiorstwa.

## **Cena**

Gdy aplikacja wykorzystuje Microsoft Office Automation, należy zakupić kopię Microsoft Office dla każdego komputera, na którym aplikacja jest uruchamiana. Wielokrotnie zdarza się, że aplikacja musi tworzyć lub modyfikować plik Office, ale nie wymaga od użytkownika posiadania Microsoft Office. Aspose oferuje bardzo [opłacalną](https://purchase.aspose.com/) i wolną od opłat licencyjnych licencję na redystrybucję, która pozwala na wdrożenie na nieograniczoną liczbę użytkowników bez obaw o licencjonowanie.

Tworząc aplikacje internetowe, ważne jest, aby wiedzieć, że komponenty Microsoft Office Automation nie są wyceniane ani licencjonowane do rozwiązań po stronie serwera; w związku z tym nie ma dobrej, licencyjnej opcji wdrażania aplikacji internetowych wykorzystujących komponenty Microsoft Office. Aspose oferuje również bardzo opłacalne rozwiązanie dla aplikacji serwerowych.

## **Funkcje**

Komponenty Aspose zapewniają wszystko, co potrzebne do zarządzania plikami Office, plus wiele więcej. Zostały zaprojektowane zgodnie z filozofią umożliwiającej programistom osiąganie najlepszych rezultatów przy minimalnym nakładzie pracy. W przeciwieństwie do Office Automation, komponenty Aspose oferują wiele potężnych i oszczędzających czas funkcji. Na przykład, [Aspose.Cells](https://products.aspose.com/cells/java/) daje programistom możliwość importowania danych z **DataTable** lub **DataView** bezpośrednio do pliku Excel. [Aspose.Words](https://products.aspose.com/words/java/) oferuje podobną funkcję, umożliwiającą programistom wypełnienie dokumentu Word (czyli Mail Merge). [Każdy komponent](https://products.aspose.com/total/java/) z rodziny Aspose posiada własny zestaw unikalnych i potężnych funkcji.

Najlepszą częścią zakupu komponentu Aspose (lub pakietu komponentów, takiego jak [Aspose.Total](https://products.aspose.com/total/java/)) jest dostęp do naszych zespołów deweloperskich. Nasze zespoły rozumieją, że jeśli Twoja firma potrzebuje określonej funkcji, bardzo prawdopodobne, że potrzebują jej także inne firmy. Chociaż nie każda prośba o funkcję może zostać zrealizowana, nasze zespoły starają się być bardzo otwarte i elastyczne przy udzielaniu pomocy. To podejście pomogło komponentom Aspose stać się tak potężnymi, jakimi są. Jeśli potrzebujesz dodatkowych funkcji z obiektów Office Automation, Twoje szanse na ich dodanie są bardzo, bardzo niskie.

## **Podsumowanie**
{{% alert color="info" %}} 

Chociaż ten artykuł omawia wiele kluczowych powodów, dla których komponenty Aspose są lepszym wyborem niż Office Automation, istnieje jeszcze wiele, wiele innych. Ten artykuł koncentruje się głównie na najważniejszych punktach. Wszystkie różne komponenty Aspose oferują bezpłatną, bez zobowiązań [Wersję ewaluacyjną](https://downloads.aspose.com/slides/pl/java). Zachęcamy do skorzystania z tej wersji, aby lepiej zobaczyć, co Aspose może zrobić dla Twoich aplikacji. 

{{% /alert %}}