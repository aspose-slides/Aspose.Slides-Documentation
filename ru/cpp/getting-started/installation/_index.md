---
title: Установка
type: docs
weight: 70
url: /ru/cpp/installation/
keywords:
- установить Aspose.Slides
- скачать Aspose.Slides
- использовать Aspose.Slides
- установка Aspose.Slides
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- презентация
- C++
- Aspose.Slides
description: "Узнайте, как быстро установить Aspose.Slides для C++. Пошаговое руководство, системные требования и примеры кода — начните работать с презентациями PowerPoint уже сегодня!"
---

## **Windows**
NuGet предоставляет самый простой способ загрузки и установки API Aspose для C++ на ПК. 

### **Вариант 1: Установить или обновить Aspose.Slides для C++ через менеджер пакетов NuGet**

1. Откройте Microsoft Visual Studio. 
2. Создайте простое консольное приложение. Или откройте ваш предпочтительный проект. 
3. Перейдите в **Tools** > **NuGet package manager**.
4. В разделе **Browse** введите *Aspose.Slides.Cpp* в текстовое поле. 

![todo:image_alt_text](installation_1.png)

3. Нажмите на нужную вам версию **Aspose.Slides.Cpp** и затем нажмите **Install**. 
   * Если вы хотите обновить Aspose.Slides (это значит, что он уже установлен), нажмите **Update** вместо этого. 

Выбранный API загружается и добавляется в ваш проект.

### **Вариант 2: Установить или обновить Aspose.Slides через консоль менеджера пакетов**

Чтобы сослаться на [Aspose.Slides API](https://www.nuget.org/packages/Aspose.Slides.Cpp/) с помощью консоли менеджера пакетов, выполните следующее:

1. Откройте ваше решение/проект в Visual Studio.

1. Перейдите в **Tools** > **NuGet Package Manager** > **Package Manager Console**. 

   Откроется консоль Package Manager Console. 

![todo:image_alt_text](installation_2.png)

4. Введите эту команду: `Install-Package Aspose.Slides.Cpp` 
> Если вы хотите установить x86‑версию, используйте пакет Aspose.Slides.Cpp.x86: `Install-Package Aspose.Slides.Cpp.x86`

5. Нажмите клавишу Enter.

   В ваше приложение устанавливается последняя полная версия. 

   * Кроме того, вы можете добавить суффикс `-prerelease` к команде, чтобы установить также последнюю версию (включая исправления).

![todo:image_alt_text](installation_3.png)

​	После завершения загрузки вы должны увидеть сообщения подтверждения.  

![todo:image_alt_text](installation_4.png)

Если вы не знакомы с [Aspose EULA](https://about.aspose.com/legal/eula), возможно, вы захотите прочитать лицензию, указанную по этой ссылке. 

В консоли Package Manager Console вы можете выполнить команду `Update-Package Aspose.Slides.Cpp`, чтобы проверить наличие обновлений пакета Aspose.Slides. Обновления (если найдены) устанавливаются автоматически. Вы также можете использовать суффикс `-prerelease` для обновления последней версии.

### **Использование папок Include и lib**
1. Скачайте последнюю версию Aspose.Slides для C++.
1. Разархивируйте папку в производственной среде.
1. Чтобы использовать Aspose.Slides для C++, добавьте ссылки на папки Include и lib в ваш проект

## **FAQ**

**Есть ли бесплатная версия или ограничения пробной версии?**

Да, по умолчанию Aspose.Slides работает в режиме оценки, который накладывает водяные знаки и может иметь другие ограничения. Чтобы снять ограничения, необходимо применить действующую [license](/slides/ru/cpp/licensing/).