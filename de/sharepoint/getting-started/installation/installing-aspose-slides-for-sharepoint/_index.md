---  
title: Installation von Aspose.Slides für SharePoint  
type: docs  
weight: 10  
url: /sharepoint/installing-aspose-slides-for-sharepoint/  
---  

{{% alert color="primary" %}}  

Aspose.Slides für SharePoint wird als das Aspose.Slides.SharePoint.zip-Archiv heruntergeladen. Das Archiv enthält:  

- **Aspose.Slides.SharePoint.wsp**: SharePoint-Lösungsdatei. Aspose.Slides für SharePoint ist als SharePoint-Lösung verpackt, um die Aktivierung und Deaktivierung über den Serverfarm zu erleichtern.  
- **Aspose_LicenseAgreement.rtf**: Die Endbenutzer-Lizenzvereinbarung.  
- **Setup.exe**: Das Installationsprogramm.  
- **Setup.exe.config**: Die Installationskonfigurationsdatei.  

{{% /alert %}}  
## **Installationsprozess**  
Vor der Ausführung der Installation überprüft das Installationsprogramm, dass:  

- WSS 3.0 oder MOSS 2007 installiert ist.  
- Der Benutzer die Berechtigung hat, SharePoint-Lösungen zu installieren.  
- Die SharePoint-Datenbank online ist.  
- Der WSS-Administrationsdienst gestartet ist.  
- Der WSS-Timerdienst gestartet ist.  

Die WSS-Administrations- und Timer-Dienste sind erforderlich, da einige Installationsaktionen auf einen Timer-Job angewiesen sind, um auf alle Server in der Serverfarm zu propagieren.  
### **Ausführen der Installation**  
Um Aspose.Slides für SharePoint zu installieren:  

1. Entpacken Sie das Aspose.Slides.SharePoint.zip auf das lokale Laufwerk des MOSS 7.0 oder WSS 3.0 Servers.  
2. Führen Sie setup.exe aus und folgen Sie den Anweisungen auf dem Bildschirm.  
   Das Installationsprogramm führt die folgenden Aktionen durch:  
   1. Überprüft die Installationsvoraussetzungen. Die Installation wird nicht fortgesetzt, wenn eine Überprüfung fehlschlägt.  

      **Durchführung einer Systemprüfung**  

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_1.png)  

3. Zeigt die Endbenutzer-Lizenzvereinbarung an. Sie müssen der Vereinbarung zustimmen, um fortzufahren.  

   **Die EULA**  

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_2.png)  

4. Zeigt die Auswahl der Bereitstellungsziele an. Wählt die Webanwendungen und Websitekollektionen aus, für die die Funktion aktiviert werden soll.  

   **Auswahl der Bereitstellungsziele**  

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_3.png)  

5. Bereitgestellt die Funktion für die Serverfarm.  

   **Der Installationsfortschrittsbalken**  

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_4.png)  

6. Aktiviert Aspose.Slides für die ausgewählten Websitekollektionen und konfiguriert deren übergeordnete Webanwendungen.  
7. Zeigt eine Liste der Webanwendungen und Websitekollektionen an, für die die Funktion bereitgestellt und aktiviert wurde.  

   **Erfolgreiche Installation**  

![todo:image_alt_text](installing-aspose-slides-for-sharepoint_5.png)  