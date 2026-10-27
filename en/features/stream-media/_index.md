---
title: Stream large media while processing presentations
description: Keep large embedded media on disk while processing a presentation.
type: docs
url: /features/stream-media/
weight: 280
feature_id: stream-media
feature_group: operations
translationKey: slides-feature-stream-media
feature_catalogue_version: 2
feature_guides:
- /slides/net/manage-blob/
---

## **Overview**

Use the library's BLOB-management options for presentations with large video, audio or image data. These options can keep media in the source stream or temporary files instead of loading every media byte into memory. Keep the required stream open for the chosen locking behavior.

## **FAQ**

**Does this stream the entire slide model?**

No. Slides, shapes and other document objects are still held in memory. The savings mainly concern embedded binary media.

## **Guides**

- [Manage Presentation BLOBs in .NET for Efficient Memory Use](/slides/net/manage-blob/)

Related feature: [Control memory used by embedded media](/slides/features/memory-management/).
