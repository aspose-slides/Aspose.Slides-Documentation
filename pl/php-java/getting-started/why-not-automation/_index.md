---
title: Dlaczego nie automatyzować
type: docs
weight: 50
url: /pl/php-java/why-not-automation/
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
- PHP
- Aspose.Slides
description: "Dowiedz się, dlaczego automatyzacja Office jest ryzykowna dla serwerów i usług, oraz zobacz, jak Aspose.Slides zapewnia bezpieczniejsze i szybsze przetwarzanie prezentacji dla PowerPoint i OpenDocument."
---
## **Przegląd**

Istnieje kilka powodów, dla których komponenty Aspose są lepszą alternatywą niż automatyzacja. Niektóre z kluczowych powodów to:

- Bezpieczeństwo
- Stabilność
- Skalowalność/Szybkość
- Cena
- Funkcje

Poniżej znajduje się bardziej szczegółowe wyjaśnienie każdego z kluczowych punktów.

## **Ważne pytania**

Słyszymy dwa pytania, które często padają w Aspose:

- Czy Twoje produkty wymagają zainstalowanego Microsoft Office, aby działały?

Krótka, prosta odpowiedź to **NIE**.

Komponenty Aspose są całkowicie niezależne i nie są powiązane, autoryzowane, sponsorowane ani w żaden sposób zatwierdzone przez Microsoft Corporation.

- Dlaczego powinniśmy używać produktów Aspose zamiast automatyzacji Microsoft Office?

Po pierwsze, istnieje wiele [korzyści, które zyskujesz używając Aspose.Slides](/slides/pl/php-java/product-overview/).

Po drugie, sam Microsoft zdecydowanie **odradza** używanie automatyzacji Office w rozwiązaniach programowych.

## **Bezpieczeństwo**

Poniżej znajduje się dosłowny cytat z artykułu Microsoft: 

*"Aplikacje Office nigdy nie były przeznaczone do użycia po stronie serwera i dlatego nie uwzględniają problemów bezpieczeństwa, z jakimi borykają się komponenty rozproszone. Office nie uwierzytelnia przychodzących żądań i nie chroni przed nieświadomym uruchamianiem makr lub uruchamianiem kolejnego serwera, który może uruchamiać makra, z kodu po stronie serwera. Nie otwieraj plików przesłanych na serwer z anonimowej sieci WWW! W zależności od ostatnich ustawień bezpieczeństwa, serwer może uruchamiać makra w kontekście Administratora lub Systemu z pełnymi uprawnieniami i narazić Twoją sieć na niebezpieczeństwo! Dodatkowo Office używa wielu komponentów po stronie klienta (takich jak Simple MAPI, WinInet, MSDAIPP), które mogą buforować informacje uwierzytelniające klienta w celu przyspieszenia przetwarzania. Jeśli Office jest automatyzowany po stronie serwera, jedna instancja może obsługiwać więcej niż jednego klienta i ponieważ informacje uwierzytelniające zostały zapisane w pamięci podręcznej dla tej sesji, istnieje możliwość, że jeden klient może użyć zapisanych poświadczeń innego klienta, uzyskując w ten sposób nieprzyznane uprawnienia poprzez podszywanie się pod innych użytkowników."* 

Aspose produktów są bardzo bezpieczne. Komponenty Aspose nie stanowią potencjalnego ryzyka dla kluczowych zasobów systemu. Co więcej, gdy dokument jest otwierany przez komponent Aspose, makra nie są uruchamiane automatycznie. Komponenty Aspose zostały stworzone z myślą o umożliwieniu programistom tworzenia, modyfikowania i zapisywania plików Office. Żadne z ryzyk związanych z pakietem Microsoft Office nie są wrodzone dla komponentów Aspose. 

## **Stabilność**
Poniżej znajduje się dosłowny cytat z artykułu Microsoft: 

*"Office 2000, Office XP i Office 2003 wykorzystują technologię Microsoft Windows Installer (MSI), aby ułatwić instalację i samonaprawę dla użytkownika końcowego. MSI wprowadza koncepcję „instalacji przy pierwszym użyciu”, co pozwala dynamicznie instalować lub konfigurować funkcje w czasie działania (dla systemu lub częściej dla konkretnego użytkownika). W środowisku po stronie serwera spowalnia to wydajność i zwiększa prawdopodobieństwo pojawienia się okna dialogowego, które prosi użytkownika o zatwierdzenie instalacji lub podanie odpowiedniego dysku instalacyjnego. Mimo że ma to na celu zwiększenie odporności Office jako produktu dla użytkownika końcowego, implementacja możliwości MSI w Office jest niekorzystna w środowisku po stronie serwera. Co więcej, stabilność Office ogólnie nie może być zapewniona przy uruchamianiu po stronie serwera, ponieważ nie został on zaprojektowany ani przetestowany do takiego zastosowania. Używanie Office jako komponentu usługowego na serwerze sieciowym może obniżyć stabilność tej maszyny, a w konsekwencji całej sieci. Jeśli planujesz automatyzację Office po stronie serwera, postaraj się odizolować program na dedykowanym komputerze, który nie może wpływać na krytyczne funkcje i który może być w razie potrzeby ponownie uruchamiany."* 

Komponenty Aspose zostały gruntownie przetestowane i są niezwykle stabilne. Komponenty Aspose są używane przez [Firmy](https://about.aspose.com/customers) takie jak: **IBM**, **Hilton**, **Reader's Digest**, **Bank of America** i wiele, wiele innych. 

## **Skalowalność/Szybkość**
Poniżej znajduje się dosłowny cytat z artykułu Microsoft: 

*"Komponenty po stronie serwera muszą być wysoce reentrancyjne, wielowątkowe komponenty COM o minimalnym narzucie i wysokiej przepustowości dla wielu klientów. Aplikacje Office są pod prawie każdym względem ich dokładnym przeciwieństwem. Są to nie-reentrancyjne serwery automatyzacji oparte na STA, zaprojektowane do zapewniania różnorodnej, ale zasobochłonnej funkcjonalności dla jednego klienta. Oferują niewielką skalowalność jako rozwiązanie po stronie serwera i mają stałe limity ważnych elementów, takich jak pamięć, które nie mogą być zmieniane poprzez konfigurację. Co ważniejsze, używają globalnych zasobów (takich jak pliki mapowane w pamięci, globalne dodatki lub szablony oraz współdzielone serwery automatyzacji), co może ograniczać liczbę jednocześnie działających instancji i prowadzić do warunków wyścigu, jeśli są konfigurowane w środowisku wieloklienckim. Programiści, którzy planują uruchomić więcej niż jedną instancję dowolnej aplikacji Office jednocześnie, muszą rozważyć* ***Pula*** *lub* ***Serializacja dostępu*** *do aplikacji Office, aby uniknąć potencjalnych* ***Zakleszczeń*** *lub* ***Uszkodzenia danych*** *.* 

Komponenty Aspose są wysoce skalowalne i błyskawicznie szybkie. Aplikacje Office nie zostały zaprojektowane do jednoczesnego użycia przez setki i tysiące użytkowników. Jednak komponenty Aspose są właśnie do tego przeznaczone. Nasze komponenty działają bezbłędnie zarówno na pojedynczym serwerze, obsługując jedną aplikację, jak i w zrównoważonym obciążeniowo formularzu internetowym obsługującym aplikację na skalę całego przedsiębiorstwa. 

## **Cena**
Gdy aplikacja wykorzystuje automatyzację Microsoft Office, konieczne jest zakupienie kopii Microsoft Office dla każdego komputera, na którym aplikacja jest uruchamiana. Często aplikacja musi tworzyć lub modyfikować plik Office, ale nie wymaga od użytkownika posiadania Microsoft Office. Aspose oferuje bardzo [opłacalną](https://purchase.aspose.com/) i wolną od opłat licencyjnych umowę o redystrybucję, która umożliwia wdrożenie na nieograniczoną liczbę użytkowników bez obaw o licencjonowanie. 

Podczas tworzenia aplikacji internetowych ważne jest, aby wiedzieć, że komponenty automatyzacji Microsoft Office nie są wycenione ani licencjonowane dla rozwiązań po stronie serwera; w związku z tym nie istnieje dobre rozwiązanie licencyjne dla wdrażania aplikacji webowych wykorzystujących komponenty Microsoft Office. Aspose oferuje również bardzo opłacalne rozwiązanie dla aplikacji opartych na serwerze. 

## **Funkcje**
Komponenty Aspose zapewniają wszystko, co potrzebne do zarządzania plikami Office, a nawet więcej. Zostały zaprojektowane z myślą o umożliwieniu programistom osiągnięcia maksymalnych rezultatów przy minimalnym nakładzie pracy. W przeciwieństwie do automatyzacji Office, komponenty Aspose oferują wiele potężnych i oszczędzających czas funkcji. Na przykład, [Aspose.Cells](https://products.aspose.com/cells/php-java/) umożliwia programistom importowanie danych z **DataTable** lub **DataView** bezpośrednio do pliku Excel. [Każdy komponent](https://products.aspose.com/total/php-java/) w rodzinie Aspose oferuje własny zestaw unikalnych i potężnych funkcji.

Najlepszą częścią zakupu komponentu Aspose (lub zestawu komponentów, takiego jak [Aspose.Total](https://products.aspose.com/total/php-java/)) jest dostęp do naszych zespołów deweloperskich. Nasze zespoły zdają sobie sprawę, że jeśli istnieje funkcja, której potrzebuje Twoja firma, najprawdopodobniej będą jej potrzebować także inne firmy. Choć nie każda prośba o funkcję może zostać spełniona, nasze zespoły starają się być bardzo otwarte i elastyczne przy udzielaniu pomocy. To podejście pomogło komponentom Aspose stać się tak potężnymi, jakimi są. Jeśli potrzebujesz dodatkowych funkcji z obiektów automatyzacji Office, Twoje szanse na ich dodanie są bardzo, bardzo niskie.

## **Wniosek**
{{% alert color="primary" %}} 

Choć ten artykuł omówił wiele kluczowych powodów, dla których komponenty Aspose są lepszym wyborem niż automatyzacja Office, istnieje znacznie więcej. Ten artykuł koncentruje się głównie na najważniejszych punktach. Wszystkie różne komponenty Aspose oferują wersję [Ewaluacyjną](https://downloads.aspose.com/slides/pl/java) bez ryzyka i bez zobowiązań. Zachęcamy do skorzystania z tej wersji Ewaluacyjnej, aby lepiej przekonać się, co Aspose może zrobić dla Twoich aplikacji. 

{{% /alert %}}