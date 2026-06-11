---
title: Najczęściej zadawane pytania
type: docs
weight: 110
url: /pl/reportingservices/frequently-asked-questions/
---
{{% alert color="primary" %}} 

Ta strona zbiera szereg często zadawanych pytań dotyczących:

- [Obsługiwane formaty plików](#Supported-File-Formats).
- [Wsparcie dla usług raportowania Power BI](#Support-for-Power-BI-Reporting-services).
- [Instalacja](#Installation).
- [Konfiguracja eksportu](#Export-Configuration).

{{% /alert %}} 
### **Obsługiwane formaty plików**
#### **Q: Jakie formaty można wyeksportować raporty przy użyciu Aspose.Slides for Reporting Services?**
**A**: Aspose.Slides for Reporting Services umożliwia eksport dowolnego raportu w formacie PPT, PPS, PPTX, PPSX, XPS lub RPL.
### **Wsparcie dla usług raportowania Power BI**
#### **Q: Czy Aspose.Slides for Reporting Services obsługuje Power BI?**
**A**: Tak. Aspose.Slides for Reporting Services obsługuje eksport raportów stronicowanych (RDL) w Power BI.
### **Instalacja**
#### **Q: Program instalacyjny nie uruchamia się. Ręczna instalacja nie prowadzi do oczekiwanego rezultatu.**
**A** : Upewnij się, że w systemie zainstalowany jest .NET Framework 3.5.
#### **Q: Brak opcji eksportu po zainstalowaniu Aspose.Slides for Reporting Services.**
**A**: Jeśli jakikolwiek CodeGroup w rssrvpolicy.config nie działa prawidłowo, parser pliku konfiguracyjnego może pominąć ostatnie sekcje grupy. Przenieś więc wszystkie CodeGroupy powiązane z Aspose.Slides for Reporting Services na początek bloku zawierającego CodeGroupy Aspose.Slides for Reporting Services.
#### **Q: Nie można załadować pliku lub zestawu Aspose.Slides.ReportingServices (Nie można uzyskać uprawnienia wykonania \ Wyjątek z HRESULT: 0x80131418).**
**A**: Kod błędu (0x80131418) wskazuje, że moduł dll nie ma wystarczających uprawnień. Może to wynikać z funkcji zabezpieczeń, która zablokowała pełny dostęp do pliku .dll, jeśli został on uzyskany z innego komputera. Można to naprawić, otwierając okno właściwości pliku dll i klikając przycisk "Unblock" w panelu "Security".
#### **Q: Nie można odnaleźć licencji 'Aspose.Slides.Reporting.Services.lic'.**
**A**: Plik licencji musi znajdować się obok pliku dll lub w katalogu Program Files (x86)\Aspose\Slides\.
### **Konfiguracja eksportu**
#### **Q: Jak mogę zmienić kolor hiperłączy w wyeksportowanym raporcie?**
**A**: Każde rozszerzenie renderujące Aspose.Slides for Reporting Services w pliku rsreportserver.config ma własną konfigurację. Aby zmienić kolor hiperłącza, ustaw żądaną wartość w sekcji <HyperlinkColor>.
#### **Q: W wyeksportowanych prezentacjach tekst w tabelach jest rozciągnięty pionowo.**
**A**: Dzieje się tak, aby dokument był łatwiejszy do odczytania. Aby wyświetlić tekst w tabeli tak, jak pojawia się w raporcie, ustaw wymagane rozszerzenie Aspose.Slides for Reporting Services na "Normal" w pliku konfiguracyjnym rsreportserver.config.