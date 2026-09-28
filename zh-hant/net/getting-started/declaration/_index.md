---
title: 信任層級需求
type: docs
weight: 190
url: /zh-hant/net/declaration/
keywords:
- 信任層級
- 完整信任權限
- 部份信任
- 中等信任
- 程式碼存取安全性
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET 所需的程式碼存取安全性信任層級：在 .NET Framework 上需要完整信任，而在 .NET 6 及之後則不需要設定信任層級。"
---
## **概觀**

程式碼存取安全性 (CAS) 信任層級僅在 .NET Framework 中存在。本篇說明它們對 Aspose.Slides for .NET 的意義：此函式庫在 .NET Framework 上需要完整信任，而在 .NET 6 及之後的版本中則沒有可設定的信任層級。

## **.NET Framework**

Aspose.Slides 在 .NET Framework 上需要完整信任。它無法在部份信任下執行，例如已設定為 Medium Trust (`<trust level="Medium" />`) 的 ASP.NET 應用程式：建立 [簡報](https://reference.aspose.com/slides/zh-hant/net/aspose.slides/presentation/) 物件會失敗，拋出 `SecurityException`。

Microsoft 已不再將 ASP.NET 部份信任視為應用程式彼此隔離的方式，建議改以獨立的應用程式集區執行。請參閱 [ASP.NET 部份信任無法保證應用程式隔離](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation)。

## **.NET 6 及之後的版本**

程式碼存取安全性在 .NET 6 及之後的版本中不可用，因而沒有可授予的信任層級。Aspose.Slides 會以執行您應用程式的帳戶權限運行。若要限制應用程式的存取範圍，Microsoft 建議使用作業系統層面的界線，例如使用者帳戶、容器或虛擬機器。請參閱 [程式碼存取安全性 (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas)。

## **常見問答**

**我可以在採用 Medium Trust 執行 ASP.NET 應用程式的託管服務商上使用 Aspose.Slides 嗎？**

無法在 Medium Trust 下使用。在 .NET Framework 上，使用 Aspose.Slides 的應用程式必須以完整信任執行。