---
title: 開始使用
type: docs
weight: 10
url: /zh-hant/net/getting-started/
keywords:
- 入門
- 系統需求
- 安裝
- 第一個簡報
- NuGet
- PPT 處理
- PPTX 處理
- ODP 處理
- PowerPoint
- OpenDocument
- 簡報
- .NET
- C#
- Aspose.Slides
description: "從新 .NET 專案到使用 Aspose.Slides 儲存的第一個簡報的路徑：檢查需求、安裝套件、執行第一個程式，並繼續執行常見任務。"
---
## **概述**

依序完成以下四個步驟。每個步驟說明要做什麼，並連結至詳細說明的文章。步驟完成後會介紹評估、授權與支援。

## **步驟 1：檢查系統需求**

[Aspose.Slides for .NET](https://products.aspose.com/slides/net/) 可在 Windows、Linux 與 macOS 上執行。[系統需求](/slides/zh-hant/net/system-requirements/) 列出各套件支援的作業系統與 .NET 版本，以及 Linux 需額外安裝的函式庫。

## **步驟 2：安裝套件**

Aspose.Slides for .NET 透過 NuGet 發行為兩個提供相同類別的套件。將其中一個套件加入您的專案：

- 在 Windows 上： `dotnet add package Aspose.Slides.NET`
- 在 Linux 和 macOS 上： `dotnet add package Aspose.Slides.NET6.CrossPlatform`。在 Linux 上，請先安裝 `fontconfig` 函式庫。
- 在 Alpine Linux，以及 glibc 低於 2.23（x64）或 2.39（ARM64）的 Linux 系統上：使用 Aspose.Slides.NET，並安裝 `libgdiplus` 函式庫。

[安裝說明](/slides/zh-hant/net/installation/) 提供 Linux 指令、Aspose.Slides.NET 在 Linux 上所需的額外啟動設定，以及 Visual Studio 的安裝步驟。

## **步驟 3：建立您的第一個簡報**

[ Aspose.Slides for .NET 主頁上的快速入門](/slides/zh-hant/net/#your-first-presentation) 是完整的主控台程式範例：它會在投影片上加入文字方塊，並將簡報儲存為 PPTX 檔案。[建立簡報](/slides/zh-hant/net/create-presentation/) 以更詳細的方式說明相同步驟，並示範如何開啟現有簡報以及將其儲存為其他格式。

## **步驟 4：繼續常見任務**

- [開啟簡報](/slides/zh-hant/net/open-presentation/)
- [保存簡報](/slides/zh-hant/net/save-presentation/)
- [將簡報轉換為 PDF](/slides/zh-hant/net/convert-powerpoint-to-pdf/)
- [將投影片渲染為圖片](/slides/zh-hant/net/convert-slide/)
- [編輯簡報文字](/slides/zh-hant/net/manage-text/)
- [按投影片元素的範例](/slides/zh-hant/net/examples/)

## **評估與授權**

如果沒有授權，Aspose.Slides 會以評估模式執行：它會在每張保存的投影片上加上浮水印，並截斷從簡報中讀取的文字。

- [評估 Aspose.Slides](/slides/zh-hant/net/evaluate-aspose-slides/) 說明評估限制以及如何申請臨時授權。
- [授權](/slides/zh-hant/net/licensing/) 示範如何從檔案、串流或嵌入式資源套用授權。
- [計量授權](/slides/zh-hant/net/metered-licensing/) 介紹依使用量計費的授權方式。
- [支援的檔案格式](/slides/zh-hant/net/supported-file-formats/) 列出 Aspose.Slides 能載入與儲存的格式。

## **取得協助**

[產品支援](/slides/zh-hant/net/product-support/) 說明如何在 [免費支援論壇](https://forum.aspose.com/c/slides/11) 提問，以及回報問題時應提供的資訊。

## **常見問題**

**我需要安裝 Microsoft PowerPoint 嗎？**

不需要。Aspose.Slides 自行讀寫簡報檔案，並不使用 PowerPoint，因此也能在伺服器與 Linux 上執行。

**哪個套件適用於 .NET Framework 應用程式？**

Aspose.Slides.NET。它包含 .NET Framework 4.6.2 以上、.NET 6 以上以及 .NET Standard 2.0 的組建。Aspose.Slides.NET6.CrossPlatform 需要 .NET 6 或以上版本。