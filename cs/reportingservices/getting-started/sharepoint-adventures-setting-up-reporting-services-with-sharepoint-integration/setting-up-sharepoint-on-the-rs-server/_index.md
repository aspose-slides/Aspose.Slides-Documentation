---
title: Nastavení SharePointu na serveru RS
type: docs
weight: 40
url: /cs/reportingservices/setting-up-sharepoint-on-the-rs-server/
---
{{% alert color="primary" %}} 

Takže musíme udělat to, co jsme dělali pro SharePoint WFE. Prvním krokem je projít instalaci předpokladů a poté spustit instalaci SharePointu. 

Pro instalaci zvolíme Server Farm a kompletní instalaci, aby odpovídala mé SharePointové skříni, protože nechceme samostatnou instalaci pro SharePoint. 

{{% /alert %}} 
### **Konfigurace SharePointu**
V Průvodci konfigurací SharePointu se chceme připojit k existující farmě. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_1.png)

**Obrázek 13**: Průvodce konfigurací SharePointu 

Poté ji nasměrujeme na databázi **SharePoint_Config**, kterou naše farma používá. Pokud nevíte, kde se nachází, můžete to zjistit v Central Admin v sekci **System Settings -> Manager Servers in this farm.** 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_2.png)

**Obrázek 14**: Průvodce konfigurací SharePointu 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_3.png)

**Obrázek 15**: Průvodce konfigurací SharePointu 

Jakmile je průvodce dokončen, není prozatím potřeba dělat nic dalšího na serveru Report Server. Po návratu na URL ReportServeru uvidíme další chybu, ale je to proto, že jsme ji nenastavili v Central Administratoru. 

![todo:image_alt_text](setting-up-sharepoint-on-the-rs-server_4.png)

**Obrázek 16**: Chyba serveru Report