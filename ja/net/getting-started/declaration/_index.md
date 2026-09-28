---
title: 信頼レベル要件
type: docs
weight: 190
url: /ja/net/declaration/
keywords:
- 信頼レベル
- フルトラスト権限
- 部分信頼
- ミディアムトラスト
- コードアクセスセキュリティ
- ASP.NET
- .NET Framework
- PowerPoint
- OpenDocument
- プレゼンテーション
- .NET
- C#
- Aspose.Slides
description: "Aspose.Slides for .NET が必要とするコードアクセスセキュリティの信頼レベルは、.NET Framework ではフルトラスト、.NET 6 以降では信頼設定が不要です。"
---
## **概要**

コード アクセス セキュリティ (CAS) の信頼レベルは .NET Framework にのみ存在します。本記事では、Aspose.Slides for .NET におけるそれらの意味を説明します。ライブラリは .NET Framework ではフルトラストが必要で、.NET 6 以降では設定する信頼レベルはありません。

## **.NET Framework**

Aspose.Slides は .NET Framework 上でフルトラストが必要です。Medium Trust (`<trust level="Medium" />`) のように部分的な信頼で構成された ASP.NET アプリケーションでは動作せず、[Presentation](https://reference.aspose.com/slides/net/aspose.slides/presentation/) オブジェクトの作成時に `SecurityException` が発生します。

Microsoft は、ASP.NET の部分信頼をアプリケーション間の分離手段としてはもはや扱わず、代わりに個別のアプリケーション プールで実行することを推奨しています。詳しくは [ASP.NET Partial Trust does not guarantee application isolation](https://support.microsoft.com/en-us/servicing/dotnetframework/troubleshooting/asp-net-partial-trust-does-not-guarantee-application-isolation) を参照してください。

## **.NET 6 and Later**

.NET 6 以降ではコード アクセス セキュリティは利用できないため、付与すべき信頼レベルは存在しません。Aspose.Slides はアプリケーションを実行しているアカウントの権限で動作します。アプリケーションがアクセスできる範囲を制限するには、ユーザー アカウント、コンテナ、仮想マシンなど、OS の境界を使用することが Microsoft により推奨されています。詳しくは [Code access security (CAS)](https://learn.microsoft.com/en-us/dotnet/core/porting/net-framework-tech-unavailable#code-access-security-cas) を参照してください。

## **FAQ**

**ホスティングプロバイダーが ASP.NET アプリケーションを Medium Trust で実行している場合、Aspose.Slides を使用できますか？**

Medium Trust では使用できません。.NET Framework では、Aspose.Slides を使用するアプリケーションはフルトラストで実行する必要があります。