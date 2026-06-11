---
title: Konfiguracja Reporting Services SharePoint
type: docs
weight: 50
url: /pl/reportingservices/reporting-services-sharepoint-configuration/
---
{{% alert color="primary" %}} 

Teraz, gdy SharePoint jest zainstalowany i skonfigurowany na serwerze RS, a RS jest skonfigurowany przy użyciu Reporting Services Configuration Manager, możemy przejść do konfiguracji w Central Admin. RS 2008 R2 naprawdę uprościł ten proces. Wcześniej był to 3‑etapowy proces, który trzeba było wykonać, aby to zadziałało. Teraz mamy tylko jeden krok. 

Musimy przejść do witryny Central Administrator, a następnie do sekcji General Application Settings. Na dole zobaczymy Reporting Services. 

{{% /alert %}} 

![todo:image_alt_text](reporting-services-sharepoint-configuration_1.png)


**Rysunek 17**: Konfiguracja SharePoint 

{{% alert color="primary" %}} 

Kliknij „**Reporting Services Integration**”. 

{{% /alert %}} 
## **Adres URL usługi sieciowej**
Podamy adres URL serwera raportów, który znaleźliśmy w Reporting Services Configuration Manager. 
## **Tryb uwierzytelniania**
Wybierzemy również tryb uwierzytelniania. Poniższy link MSDN szczegółowo opisuje te opcje. 
[Przegląd zabezpieczeń dla Reporting Services w trybie zintegrowanym z SharePoint](https://docs.microsoft.com/en-us/previous-versions/sql/sql-server-2008-r2/bb283324(v=sql.105)) 

Krótko mówiąc, jeśli Twoja witryna używa **Claims Authentication**, zawsze będzie używać Trusted Authentication, niezależnie od wybranego tutaj ustawienia. Jeśli chcesz przekazywać poświadczenia Windows, wybierz Windows Authentication. Dla Trusted Authentication przekażemy token SPUser i nie będziemy polegać na poświadczeniach Windows. 

Trusted Authentication powinno się również używać, jeśli skonfigurowałeś witryny w trybie Classic dla NTLM i RS jest ustawiony na NTLM. Do użycia Windows Authentication i przekazania go do źródła danych potrzebny będzie Kerberos. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_2.png)


**Rysunek 18**: Ustawianie danych uwierzytelniających dla Reporting Services Integration
## **Aktywuj funkcję**
To daje możliwość aktywacji Reporting Services we wszystkich kolekcjach witryn, lub możesz wybrać, w których chcesz je aktywować. Oznacza to po prostu, które witryny będą mogły korzystać z Reporting Services. 
Po zakończeniu powinieneś zobaczyć następujący rysunek. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_3.png)


**Rysunek 19**: Pomyślna integracja Reporting Services ze środowiskiem SharePoint 

Wracając do adresu URL serwera raportów podanego na Rysunku 14, powinniśmy zobaczyć coś podobnego do poniższego rysunku. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_4.png)


**Rysunek 20**: Pomyślna weryfikacja Reporting Services ze środowiskiem SharePoint 

{{% alert color="primary" %}} 

Jeśli Twoja witryna SharePoint jest skonfigurowana pod SSL, nie pojawi się ona na tej liście. To znany problem i nie oznacza, że jest coś nie tak. Twoje raporty powinny nadal działać. 

{{% /alert %}} 

Teraz jesteśmy gotowi do używania Reporting Services w SharePoint 2010. Podobnie jak w poprzedniej wersji, mamy funkcję (aktywowaną podczas konfigurowania Reporting Services Integration) w „Site Collection Feature”. Instalacja dodała również 3 typy treści do naszej witryny. Na Rysunku 21 widać 2 z nich dodane do biblioteki dokumentów w celu utworzenia niestandardowego raportu, jak widać na Rysunku 21. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_5.png)


**Rysunek 21**: Report Builder 

„**Reporter Builder**” to komponent ActiveX, który musimy pobrać na serwer, co widać na Rysunku 22. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_6.png)


**Rysunek 22**: Pobierz i zainstaluj Report Builder 

Po zakończeniu pobierania uruchom **Report Builder**. Teraz jesteśmy gotowi zaprojektować nasz pierwszy raport, co widać na Rysunku 23. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_7.png)

**Rysunek 23**: Kreator tworzenia nowego raportu w Report Builder 

Po utworzeniu raportu możemy go zapisać w utworzonej bibliotece dokumentów, aby umieścić raporty w naszym SharePoint 2010. 

Drugi typ treści należy użyć do utworzenia współdzielonego połączenia jako źródła danych i zapisać je w bibliotece dokumentów w SharePoint. Możemy utworzyć bibliotekę dokumentów, dodać ten typ treści i w ten sposób mieć dostępne połączenia, które można zmienić jako źródło danych raportów. 

![todo:image_alt_text](reporting-services-sharepoint-configuration_8.png)


**Rysunek 24**: Pomyślny eksport raportu do serwera raportów