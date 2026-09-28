---
title: Konfiguracja dem
type: docs
weight: 70
url: /pl/jasperreports/demos-setup/
description: "Skonfiguruj projekty demonstracyjne pobrane z Aspose.Slides for JasperReports, zmień klasę eksportera, której używają, i zbuduj je przy użyciu Ant."
---
## **Czym są dema**

Folder *samples* pobranego Aspose.Slides for JasperReports zawiera osiem projektów demonstracyjnych: *charts*, *fonts*, *images*, *landscape*, *shapes*, *subreport*, *text* i *xmldatasource*. Są to standardowe dema JasperReports, zmodyfikowane w celu dodania celu kompilacji `ppt`, który eksportuje wypełniony raport do PPT. Pobranie nie zawiera wyeksportowanych prezentacji; tworzysz je, budując demo.

## **Zmień klasę eksportera przed budowaniem**

W wersji dostarczonej kod Java dem używa `com.aspose.slides.jasperreports.JRPptExporter`, klasy, której nie ma w bieżących jarach, więc dema się nie kompilują. W klasie aplikacji dem (na przykład *ShapesApp.java* w demie *shapes*), zamień `JRPptExporter` na `ASPptExporter`, eksportera PPT w tym samym pakiecie. Demo *fonts* importuje cały pakiet, więc zmienia się tylko nazwa klasy w jego kodzie.

Dema używają także klas JasperReports, które w późniejszych wersjach JasperReports zostały usunięte, takich jak `JExcelApiExporter` i `JRExporterParameter.FONT_MAP`. Po powyższej zmianie dema kompilują się następująco:

| Wersja JasperReports | Dema które się kompilują |
| :- | :- |
| 5.5.1 | wszystkie osiem |
| 5.5.2 i 6.4.0 | *charts*, *images*, *landscape*, *shapes* i *xmldatasource* |
| 6.16.0 | *charts* |

## **Zbuduj demo**

Każdy *build.xml* dem oczekuje struktury folderów projektu JasperReports: kompiluje się względem *../../../build/classes* oraz jarów w *../../../lib*, względem folderu dem.

1. Skopiuj folder dem do *demo/samples* w folderze projektu JasperReports.  
2. Skopiuj *aspose.slides.jasperreports.library-xx.x.jar* z podfolderu *lib* pobranego pakietu, odpowiadającego Twojej wersji JasperReports, do folderu *lib* projektu JasperReports. Zobacz [Instalowanie Aspose.Slides dla JasperReports](/slides/pl/jasperreports/installing-aspose-slides-for-jasperreports/).  
3. Umieść jar swojej wersji JasperReports oraz jary, od których on zależy, w tym samym folderze *lib*. Poza plikami dem, *build.xml* dodaje do ścieżki klas jedynie *build/classes* i jary znajdujące się w *lib*, a *build/classes* zawiera klasy JasperReports dopiero po skompilowaniu JasperReports ze źródeł.  
4. Dema *charts*, *subreport* i *text* odczytują przykładową bazę danych HSQLDB JasperReports (`jdbc:hsqldb:hsql://localhost`), więc najpierw uruchom jej serwer, jak opisano w *samples/Readme.txt* pobranego pakietu. Inne dema nie wymagają bazy danych.  
5. W folderze dem, skompiluj aplikację, skompiluj projekt raportu, wypełnij go i wyeksportuj do PPT:

```bash
ant javac
ant compile
ant fill
ant ppt
```

Cel `ppt` zapisuje prezentację obok wypełnionego raportu, nazwany po raporcie (na przykład *LandscapeReport.ppt*).

Dwa dema wymagają więcej niż powyższe kroki:

- Demo *images* ładuje jeden obraz z `http://jasperreports.sourceforge.net/jasperreports.png` podczas eksportu. Ten adres teraz przekierowuje na HTTPS, więc krok `ppt` nie zapisuje prezentacji, dopóki nie zmienisz adresu na `https://` w *ImagesReport.jrxml*. W JasperReports 6.4.0 eksport tego obrazu nie powodzi się nawet przez HTTPS.  
- Raport *xmldatasource* używa czcionki Arial. Na systemie bez Arial, `ant fill` wypisuje, że czcionka „is not available to the JVM” i nie tworzy wypełnionego raportu, więc `ant ppt` nie ma nic do wyeksportowania. Budowanie nadal zgłasza sukces, więc sprawdź wyjście każdego kroku.