---
title: 系統需求
type: docs
weight: 60
url: /zh-hant/python-net/system-requirements/
keywords:
- 系統需求
- 作業系統
- 安裝
- 相依性
- Windows
- Linux
- macOS
- PowerPoint
- OpenDocument
- 簡報
- Python
- Aspose.Slides
description: "了解 Aspose.Slides for Python via .NET 的系統需求。確保在 Windows、Linux 與 macOS 上順暢支援 PowerPoint 與 OpenDocument。"
---
## **簡介**

Aspose.Slides for Python via .NET 不需要安裝任何第三方產品，例如 Microsoft PowerPoint。Aspose.Slides 是一個可建立、修改、轉換與算繪各種格式文件（含 Microsoft PowerPoint 簡報格式）的引擎。

## **支援的作業系統**

Aspose.Slides for Python 支援在安裝了 Python 3.5 以上的 Windows（32 位元與 64 位元）、macOS 與 64 位元 Linux 系統上使用。

<table>  
    <tr>
        <td style="font-weight: bold; width:400px">作業系統</td>
        <td style="font-weight: bold; width:400px">版本</td>
    </tr>
    <tr>
        <td>Microsoft Windows</td>
        <td>
            <ul>
                <li>Windows 2003 Server</li>
                <li>Windows 2008 Server</li>
                <li>Windows 2012 Server</li>
                <li>Windows 2012 R2 Server</li>
                <li>Windows 2016 Server</li>
                <li>Windows 2019 Server</li>
                <li>Windows XP</li>
                <li>Windows Vista</li>
                <li>Windows 7</li>
                <li>Windows 8, 8.1</li>
                <li>Windows 10</li>
                <li>Windows 11</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>Linux</td>
        <td>
            <ul>
                <li>Ubuntu</li>
                <li>OpenSUSE</li>
                <li>CentOS</li>
                <li>其他發行版</li>
            </ul>
        </td>
    </tr>
    <tr>
        <td>macOS</td>
        <td>
            <ul>
                <li>12 “Monterey”</li>
            </ul>
        </td>
    </tr>
</table>

## **目標 Linux 與 macOS 平台的系統需求**

- GCC 6 執行時庫（或更新版本）。
- [libgdiplus](https://github.com/mono/libgdiplus)，GDI+ API 的開源實作。
- .NET Core Runtime 的相依性。**不需要**安裝 .NET Core Runtime 本身。
- 對於 Python 3.5–3.7：需要 `pymalloc` 版的 Python。`--with-pymalloc` 建置選項預設已啟用。通常 `pymalloc` 版的 Python 會在檔名中帶有 `m` 後綴。
- `libpython` 共享函式庫。`--enable-shared` Python 建置選項預設為停用，部分 Python 發行版不會包含 `libpython` 共享函式庫。某些 Linux 平台可透過套件管理員安裝（例如 `sudo apt-get install libpython3.7`）。常見問題是 `libpython` 函式庫安裝在非標準的共享函式庫路徑下。可透過在建置 Python 時使用替代庫路徑的建置選項，或在系統標準的共享函式庫目錄建立指向 `libpython` 檔案的符號連結來解決。通常 `libpython` 共享函式庫的檔名為 Python 3.5–3.7 時的 `libpythonX.Ym.so.1.0`，或 Python 3.8 以上的 `libpythonX.Y.so.1.0`（例如 `libpython3.7m.so.1.0`、`libpython3.9.so.1.0`）。

## **常見問題**

**我需要安裝 Microsoft PowerPoint 以進行轉換與算繪嗎？**

不需要，PowerPoint 並非必要；Aspose.Slides 是一個獨立的引擎，可用於[建立](/slides/zh-hant/python-net/create-presentation/)、修改、[轉換](/slides/zh-hant/python-net/convert-presentation/)，以及[算繪](/slides/zh-hant/python-net/convert-powerpoint-to-png/)簡報。

**機器上是否必須安裝特定的 .NET 版本（Core/5+/6+）？**

不必安裝 .NET Runtime 本身，但必須在 Linux/macOS 上具備其相依套件。也就是說系統需要包含通常作為 .NET 相依性安裝的套件，而不必完整安裝 Runtime。

**正確算繪需要哪些字型？**

實際上，只要簡報中使用的字型或適當的[替代字型](/slides/zh-hant/python-net/font-substitution/)可取得，即可正確算繪。為在 Linux/macOS 上取得一致的算繪結果，建議安裝常見的字型套件。

**為什麼自訂字型在 Linux 上會顯示為備用字型或缺少文字？**

若字型檔的 name-table 條目不一致或損毀，Linux 的字型匹配機制（FreeType/fontconfig）可能會選取無效記錄，導致字型無法解析。使用已修正 name-table 的字型版本或安裝一致的替代字型即可解決此問題。