---
title: Häufig gestellte Fragen
type: docs
weight: 110
url: /reportingservices/häufig-gestellte-fragen/
---

{{% alert color="primary" %}} 

Diese Seite sammelt eine Reihe von häufig gestellten Fragen zu:

- [Unterstützten Dateiformaten](#Unterstützte-Dateiformate).
- [Unterstützung für Power BI Reporting-Dienste](#Unterstützung-für-Power-BI-Reporting-Dienste).
- [Installation](#Installation).
- [Exportkonfiguration](#Exportkonfiguration).

{{% /alert %}} 
### **Unterstützte Dateiformate**
#### **F: In welche Formate können Sie Berichte mit Aspose.Slides für Reporting Services exportieren?**
**A**: Aspose.Slides für Reporting Services ermöglicht den Export von Berichten in PPT, PPS, PPTX, PPSX, XPS oder RPL-Format.
### **Unterstützung für Power BI Reporting-Dienste**
#### **F: Unterstützt Aspose.Slides für Reporting Services Power BI?**
**A**: Ja. Aspose.Slides für Reporting Services unterstützt den Export von paginierten Berichten (RDL) in Power BI.
### **Installation**
#### **F: Das Installationsprogramm startet nicht. Die manuelle Installation führt nicht zum gewünschten Ergebnis.**
**A**: Stellen Sie sicher, dass das .NET Framework 3.5 auf Ihrem System installiert ist.
#### **F: Nach der Installation von Aspose.Slides für Reporting Services fehlen Exportoptionen.**
**A**: Wenn eine Codegruppe in rssrvpolicy.config nicht korrekt funktioniert, kann der Konfigurationsdatei-Parser die letzten Abschnitte der Gruppe überspringen. Verschieben Sie daher alle Codegruppen, die mit Aspose.Slides für Reporting Services verbunden sind, an den Anfang des Blocks, der die Codegruppen von Aspose.Slides für Reporting Services enthält.
#### **F: Konnte die Datei oder Assembly Aspose.Slides.ReportingServices nicht laden (Ausführungsberechtigung kann nicht erlangt werden \ Ausnahme von HRESULT: 0x80131418).**
**A**: Der Fehlercode (0x80131418) zeigt an, dass das dll-Modul nicht über ausreichende Rechte verfügt. Dies kann an einer Sicherheitsfunktion liegen, die den vollständigen Zugriff auf die .dll-Datei blockiert hat, wenn sie von einem anderen Computer stammen. Dies kann behoben werden, indem man das Eigenschaftenfenster der dll-Datei öffnet und die Schaltfläche "Entsperren" im Bereich "Sicherheit" anklickt.
#### **F: Lizenzdatei 'Aspose.Slides.Reporting.Services.lic' kann nicht gefunden werden.**
**A**: Die Lizenzdatei muss neben der dll oder im Verzeichnis Program Files(x86)\Aspose\Slides\ liegen.
### **Exportkonfiguration**
#### **F: Wie kann ich die Farbe von Hyperlinks in einem exportierten Bericht ändern?**
**A**: Jede Rendering-Erweiterung von Aspose.Slides für Reporting Services in der rsreportserver.config hat ihre eigene Konfiguration. Um die Farbe des Hyperlinks zu ändern, setzen Sie den erforderlichen Wert im Abschnitt <HyperlinkColor>.
#### **F: In exportierten Präsentationen ist der Text in Tabellen vertikal gestreckt.**
**A**: Dies geschieht, um das Dokument leserlicher zu machen. Um den Text in der Tabelle so anzuzeigen, wie er im Bericht erscheint, setzen Sie die erforderliche Aspose.Slides für Reporting Services-Erweiterung auf "Normal" in der Konfigurationsdatei rsreportserver.config.