---
title: Декларация
type: docs
weight: 60
url: /ru/java/declaration/
---

{{% alert color="primary" %}} 

Все компоненты Aspose для Java требуют набора разрешений Full Trust. Причина в том, что компоненты Aspose для Java нуждаются в доступе к настройкам реестра, системным файлам, кроме виртуального каталога, для выполнения определенных операций, таких как разбор шрифтов и т. д. Более того, компоненты Aspose для Java основаны на основных классах системы Java, которые также в многих случаях требуют набора разрешений Full Trust. 

{{% /alert %}} 

Поставщики интернет-услуг, размещающие несколько приложений от разных компаний, чаще всего применяют уровень безопасности Medium Trust: 

- OleDbPermission недоступен. Это означает, что вы не можете использовать управляемый поставщик данных ADO.NET OLE DB для доступа к базам данных.
- EventLogPermission недоступен. Это означает, что вы не можете получить доступ к журналу событий Windows.
- ReflectionPermission недоступен. Это означает, что вы не можете использовать рефлексию.
- RegistryPermission недоступен. Это означает, что вы не можете получить доступ к реестру.
- WebPermission ограничен. Это означает, что ваше приложение может взаимодействовать только с адресом или диапазоном адресов, которые вы определили в элементе <trust>.
- FileIOPermission ограничен. Это означает, что вы можете получать доступ только к файлам в иерархии виртуального каталога вашего приложения.

{{% alert color="primary" %}} 

По вышеуказанным причинам компоненты Aspose для Java не могут использоваться на серверах, предоставляющих набор разрешений, отличный от Full Trust. 

{{% /alert %}}